import cv2
import numpy
import imutils
import functools
import tensorflow as tf
from imutils.object_detection import non_max_suppression

X = 0
Y = 1
WIDTH = 2
HEIGHT = 3

model = tf.keras.models.load_model('my_model')
net = cv2.dnn.readNet(r'east_model\frozen_east_text_detection.pb')


def loc_area(location):
    """" Calculates the area of a location
    :param location - the location of which we calculate the area
    :return the area of the location
    """
    return location[WIDTH] * location[HEIGHT]


def get_average_loc_area(locations):
    """ Calculates the average area of all the locations in a list
    :param locations - the list of locations of which we calculate the average area
    :return the average area of the locations
    """
    area_sum = 0
    for loc in locations:
        area_sum += loc_area(loc)
    return area_sum / len(locations)


def get_average_loc_height(locations):
    """ Calculates the average height of all the locations in a list
    :param locations - the list of locations of which we calculate the average height
    :return the average height of the locations
    """
    height_sum = 0
    for loc in locations:
        height_sum += loc[HEIGHT]
    return height_sum / len(locations)


def get_average_loc_width(locations):
    """ Calculates the average width of all the locations in a list
    :param locations - the list of locations of which we calculate the average width
    :return the average width of the locations
    """
    width_sum = 0
    for loc in locations:
        width_sum += loc[WIDTH]
    return width_sum / len(locations)


def are_locs_in_same_col(loc1, loc2):
    """ Checks whether two locations are in the same column
    :param loc1 - a location
    :param loc2 - a second location
    :return whether the two locations are within the same column
    """
    return loc1[X] <= loc2[X] <= loc1[X] + loc1[WIDTH] or loc2[X] <= loc1[X] <= loc2[X] + loc2[WIDTH]


def merge_small_locs(locations):
    """ Merges small locations in a list with close locations in the same column
    :param locations - a list of locations
    :return the list of locations after merging small locations
    """
    i = 0
    # get the average loc size and height before merging small locs
    avg_loc_size = get_average_loc_area(locations)
    avg_loc_height = get_average_loc_height(locations)
    while i < len(locations):
        if loc_area(locations[i]) < avg_loc_size / 2:  # if the location is smaller than average
            for j in range(i + 1, len(locations)):
                # if they are in same col and close enough
                if (are_locs_in_same_col(locations[i], locations[j])
                        and locations[i][Y] + locations[i][HEIGHT] + avg_loc_height / 2 > locations[j][Y]):
                    locations[i] = union_two_rects(locations[i], locations[j])  # merge the locations
                    locations.remove(locations[j])  # remove the original location
                    break
        i += 1
    return locations


def enlarge_small_locs(locations):
    """ enlarges small locations in a list of locations
    :param locations - a list of locations
    :return the list of locations after enlarging small locations
    """
    # get the average loc size, height and width before enlarging small locs
    avg_loc_size = get_average_loc_area(locations)
    avg_loc_width = get_average_loc_width(locations)
    avg_loc_height = get_average_loc_height(locations)
    for i in range(len(locations)):
        if loc_area(locations[i]) < avg_loc_size / 2:  # if the location is smaller than average
            # make them a bit bigger
            locations[i] = enlarge_loc(locations[i], int(avg_loc_width / 5), int(avg_loc_height / 5))
    return locations


def remove_small_locs(locations):
    """ removes small locations in a list of locations
    :param locations - a list of locations
    :return the list of locations after removing small locations
    """
    avg_loc_size = get_average_loc_area(locations)
    for loc in locations:
        if loc_area(loc) < avg_loc_size / 4:  # if the location is smaller than average
            locations.remove(loc)
    return locations


def enlarge_loc(loc, width, height):
    """ enlarges loc
    :param loc: a location
    :param width: the width we enlarge the location with
    :param height: the height we enlarge the location with
    :return: the enlarged location
    """
    loc = [loc[X] - width,
           loc[Y] - height,
           loc[WIDTH] + width * 2,
           loc[HEIGHT] + height * 2]
    if loc[X] < 0:  # if we are out of the frame in the x axis
        loc[X] = 0
        loc[WIDTH] -= width
    if loc[Y] < 0:  # if we are out of the frame in the y axis
        loc[Y] = 0
        loc[HEIGHT] -= height
    return loc


def cmp_locs_left_right(loc1, loc2):
    """ compares two locations to determine which should be before the other going from left to right
    :param loc1 - a location
    :param loc2 - a location
    :return -1 - if loc1 should be before loc2, return 1 otherwise
    """
    # if loc1 is above loc2 or in the same row but further to the left
    if loc1[Y] + loc1[HEIGHT] < loc2[Y] or (loc1[Y] < loc2[Y] + loc2[HEIGHT] and loc1[X] < loc2[X]):
        return -1
    return 1


def cmp_locs_right_left(loc1, loc2):
    """ compares two locations to determine which should be before the other going from right to left
    :param loc1 - a location
    :param loc2 - a location
    :return -1 - if loc1 should be before loc2, return 1 otherwise
    """
    # if loc1 is above loc2 or in the same row but further to the left
    if loc1[Y] + loc1[HEIGHT] < loc2[Y] or (loc1[Y] < loc2[Y] + loc2[HEIGHT] and loc1[X] > loc2[X]):
        return -1
    return 1


def merge_overlapping_locs(locations):
    """ Merges overlapping locations in a list
    :param locations - a list of locations
    :return the list of locations after merging overlapping locations
    """
    i = 0
    while i < len(locations) - 1:
        j = i + 1
        while j < len(locations):
            # get the intersection of the two locations
            intersection_rect = intersection_two_rects(locations[i], locations[j])
            if loc_area(intersection_rect) > 0:  # if the two locations overlap
                locations[i] = union_two_rects(locations[i], locations[j])  # merge them
                locations.remove(locations[j])
                j = i  # reset to see if the rectangle needs more merging
            j += 1
        i += 1
    return locations


def merge_close_locs(locations, threshold):
    """ Merges close locations in a sorted list
    :param locations - a list of sorted locations
    :param threshold - the threshold for the locations to be considered close
    :return the list of sorted locations after merging close locations
    """
    i = 0
    while i < len(locations) - 1:
        # if the two rectangles are in the same "line" and are close enough
        if locations[i][Y] + locations[i][HEIGHT] > locations[i + 1][Y] \
                and locations[i][X] + locations[i][WIDTH] + threshold > locations[i + 1][X]:
            locations[i] = union_two_rects(locations[i], locations[i + 1])  # merge them
            locations.remove(locations[i + 1])
            i = -1  # reset to see if some rectangle needs more merging
        i += 1
    return locations


def union_two_rects(rect1, rect2):
    """ gets the union of two rectangles
    :param rect1 - a rectangle
    :param rect2 - a rectangle
    :return the union of the two rectangles
    """
    x = min(rect1[X], rect2[X])
    y = min(rect1[Y], rect2[Y])
    width = max(rect1[X] + rect1[WIDTH], rect2[X] + rect2[WIDTH]) - x
    height = max(rect1[Y] + rect1[HEIGHT], rect2[Y] + rect2[HEIGHT]) - y
    return (x, y, width, height)


def intersection_two_rects(rect1, rect2):
    """ gets the intersection of two rectangles
    :param rect1 - a rectangle
    :param rect2 - a rectangle
    :return the intersection of the two rectangles
    """
    x = max(rect1[X], rect2[X])
    y = max(rect1[Y], rect2[Y])
    width = min(rect1[X] + rect1[WIDTH], rect2[X] + rect2[WIDTH]) - x
    height = min(rect1[Y] + rect1[HEIGHT], rect2[Y] + rect2[HEIGHT]) - y
    if width < 0 or height < 0:
        return (0, 0, 0, 0)  # null rect
    return (x, y, width, height)


def get_image_contours(image):
    """ gets all the contours from an image
    :param image - the image from which we get the contours
    :return the image after applying thresholding, and the contours in image in a sorted list
    """
    grayscale = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    thresh = cv2.threshold(grayscale, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]  # apply filters
    ref_cnts = cv2.findContours(thresh, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)[0]  # find the contours

    locations = []
    for (i, cnt) in enumerate(ref_cnts):  # put the contours into a list of locations
        (x, y, w, h) = cv2.boundingRect(cnt)
        locations.append([x, y, w, h])
    largest_loc = max(locations, key=loc_area)  # get the location with the largest area
    if (largest_loc[HEIGHT] * 1.1 > image.shape[0]
       and largest_loc[WIDTH] * 1.1 > image.shape[1]):  # if the largest contour is the border of the image
        thresh = cv2.threshold(grayscale, 0, 255, cv2.THRESH_BINARY_INV | cv2.THRESH_OTSU)[1]  # apply filters
        ref_cnts = cv2.findContours(thresh, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)[0]  # find the contours

        locations = []
        for (i, cnt) in enumerate(ref_cnts):  # put the contours into a list of locations
            (x, y, w, h) = cv2.boundingRect(cnt)
            locations.append([x, y, w, h])

    if not locations:  # if no locations were found
        return thresh, locations


    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs_left_right))  # sort after merging
    locations = merge_small_locs(locations)  # merge small locations
    locations = remove_small_locs(locations)  # remove the small locations we werent able to merge
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs_left_right))  # sort again after merging

    return thresh, locations


def get_character_dict():
    """ gets the character dictionary to use as a template
    :return a dictionary where each character is a key and it's value is a template image of it
    """
    image = cv2.imread(r'font2.jpg')  # read the template image of all the chars
    thresh, locations = get_image_contours(image)  # get the contours from it
    chars = {}
    for (i, c) in enumerate(locations):
        # compute the bounding box for the character, extract it, and resize it to a fixed size
        (x, y, width, height) = locations[i]
        roi = thresh[y:y + height, x:x + width]
        roi = cv2.resize(roi, (60, 90))
        # update the digits dictionary, mapping the character name to the ROI
        chars[chr(ord('!') + i)] = roi
    return chars


def get_locations_from_net_results(scores, geometry, min_confidence):
    """
    gets the locations of possible text areas from the east neural network
    :param scores: the confidence scores for the located text areas
    :param geometry: the geometrical data for the text bounding boxes
    :param min_confidence: the minimum confidence score that will be accepted as a text area
    :return: a list of locations of the possible text areas, and a list of the confidence score for each location
    """
    # grab the number of rows and columns from the scores volume, then
    # initialize our set of bounding box rectangles and corresponding confidence scores
    (numRows, numCols) = scores.shape[2:4]
    rects = []
    confidences = []

    # loop over the number of rows
    for y in range(0, numRows):
        # extract the scores (probabilities), followed by the geometrical
        # data used to derive potential bounding box coordinates that
        # surround text
        scoresData = scores[0, 0, y]
        xData0 = geometry[0, 0, y]
        xData1 = geometry[0, 1, y]
        xData2 = geometry[0, 2, y]
        xData3 = geometry[0, 3, y]
        anglesData = geometry[0, 4, y]

        # loop over the number of columns
        for x in range(0, numCols):
            # if our score does not have sufficient probability, ignore it
            if scoresData[x] < min_confidence:
                continue

            # compute the offset factor as our resulting feature maps will
            # be 4x smaller than the input image
            (offsetX, offsetY) = (x * 4.0, y * 4.0)

            # extract the rotation angle for the prediction and then
            # compute the sin and cosine
            angle = anglesData[x]
            cos = numpy.cos(angle)
            sin = numpy.sin(angle)

            # use the geometry volume to derive the width and height of
            # the bounding box
            h = xData0[x] + xData2[x]
            w = xData1[x] + xData3[x]

            # compute both the starting and ending (x, y)-coordinates for
            # the text prediction bounding box
            endX = int(offsetX + (cos * xData1[x]) + (sin * xData2[x]))
            endY = int(offsetY - (sin * xData1[x]) + (cos * xData2[x]))
            startX = int(endX - w)
            startY = int(endY - h)

            # add the bounding box coordinates and probability score to
            # our respective lists
            rects.append((startX, startY, endX, endY))
            confidences.append(scoresData[x])
    return rects, confidences


def east_get_text_locations(image, min_confidence):
    """
    gets the locations of possible text areas in an image with the east neural network
    :param min_confidence: the minimum confidence score that will be accepted as a text area
    :return: the original image, the image after resizing, a list of sorted locations of the possible text areas
    """
    # resize the image and grab the new image dimensions
    thresh = cv2.resize(image, (640, 320))
    (H, W) = thresh.shape[:2]

    # define the two output layer names for the EAST detector model that
    # we are interested -- the first is the output probabilities and the
    # second can be used to derive the bounding box coordinates of text
    layer_names = [
        "feature_fusion/Conv_7/Sigmoid",
        "feature_fusion/concat_3"]

    # construct a blob from the image and then perform a forward pass of
    # the model to obtain the two output layer sets
    blob = cv2.dnn.blobFromImage(thresh, 1.0, (W, H),
                                 (123.68, 116.78, 103.94), swapRB=True, crop=False)
    net.setInput(blob)
    (scores, geometry) = net.forward(layer_names)

    # get the locations from the net output
    (rects, confidences) = get_locations_from_net_results(scores, geometry, min_confidence)

    # apply non-maxima suppression to suppress weak, overlapping bounding
    # boxes
    boxes = non_max_suppression(numpy.array(rects), probs=confidences)

    # loop over the bounding boxes
    for i, (startX, startY, endX, endY) in enumerate(boxes):
        boxes[i] = [startX, startY, endX - startX, endY - startY]  # use width and height instead of end points
        boxes[i] = enlarge_loc(boxes[i], 0, int(boxes[i][HEIGHT] / 10))  # enlarge the boxes by a bit to reduce errors

    locations = sorted(boxes, key=functools.cmp_to_key(cmp_locs_left_right))  # sort the locations

    return image, thresh, locations


def get_text_locations(image):
    """ gets all the text locations in an image
    :param image - the image from which we get the text locations
    :return the resized image, the image after thresholding and a sorted list of all the text locations in image
    """
    rect_kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (17, 5))
    sq_kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (5, 5))
    #  resize the image and apply filters to make text locations stand out
    image = imutils.resize(image, width=600)
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    gradX = cv2.Sobel(gray, ddepth=cv2.CV_32F, dx=1, dy=0, ksize=-1)
    gradX = numpy.absolute(gradX)
    (minVal, maxVal) = (numpy.min(gradX), numpy.max(gradX))
    gradX = (255 * ((gradX - minVal) / (maxVal - minVal)))
    gradX = gradX.astype("uint8")
    gradX = cv2.morphologyEx(gradX, cv2.MORPH_CLOSE, rect_kernel)
    gradX = cv2.morphologyEx(gradX, cv2.MORPH_CLOSE, rect_kernel)
    thresh = cv2.threshold(gradX, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]
    thresh = cv2.morphologyEx(thresh, cv2.MORPH_CLOSE, sq_kernel)
    # find the contours in the image
    word_cnts = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    word_cnts = imutils.grab_contours(word_cnts)
    locations = []
    for cnt in word_cnts:  # put the contours into a list of locations
        (x, y, width, height) = cv2.boundingRect(cnt)
        locations.append((x, y, width, height))
    locations = enlarge_small_locs(locations)
    locations = merge_overlapping_locs(locations)
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs_left_right))  # sort after merging
    locations = merge_close_locs(locations, 5)
    locations = merge_small_locs(locations)
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs_left_right))  # sort again after merging
    for i in range(len(locations)):
        locations[i] = enlarge_loc(locations[i], 0, int(locations[i][HEIGHT] / 5))
    return image, thresh, locations


def get_word_template_matching(word_img, char_locs, char_templates):
    """ gets the word from an image using the character locations in it and a template for all character
    :param word_img - an image that contains a word
    :param char_locs - the locations of all characters in the image
    :param char_templates - the tamplate images for all the valid characters
    :return the word that was found in the image
    """
    word_output = ''
    for char_loc in char_locs:
        scores = []
        (x, y, width, height) = char_loc
        roi = word_img[y:y + height, x:x + width]
        roi = cv2.resize(roi, (60, 90))
        # loop over the reference characters
        for char_roi in char_templates.values():
            # apply correlation-based template matching, take the
            # score, and update the scores list
            result = cv2.matchTemplate(roi, char_roi,
                                       cv2.TM_CCOEFF)
            (_, score, _, _) = cv2.minMaxLoc(result)
            scores.append(score)
        word_output += list(char_templates.keys())[numpy.argmax(scores)]  # get the character with the highest score
    return word_output


def blur_locations(image, locations):
    """ blurs all of the locations in a list in an image
    :param image: the image in which we blur locations
    :param locations: a list of locations
    :return: the image with the blurred locations
    """
    for loc in locations:
        (x, y, w, h) = loc
        roi = image[y:y + h, x:x + w]  # separate the roi
        blur = cv2.GaussianBlur(roi, (21, 21), 0)  # apply a gaussian blur filter
        image[y:y + h, x:x + w] = blur  # insert the blurred roi back into the image
    return image


def get_label_char(classification):
    """
    get num(label) and return is matching char (latter or numbers)
    :param classification: 0 - 61
    :return: str with the char
    """
    label_str = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    return label_str[classification]


def get_label_classification(label):
    """
    get num(label) and return is matching char (latter or numbers)
    :param label: 0 - 61
    :return: str with the char
    """
    label_str = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    return label_str.find(label)


def get_word_ml(word_img, char_locs):
    """ gets the word from an image using the character locations in it and a template for all character
    :param word_img - an image that contains a word
    :param char_locs - the locations of all characters in the image
    :param model_path - the path of training model to run
    :return the word that was found in the image
    """
    char_images = []
    word_output = ''
    avg_loc_width = get_average_loc_width(char_locs)

    word_img = cv2.cvtColor(word_img, cv2.COLOR_BGR2GRAY)
    word_img = cv2.threshold(word_img, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]  # apply filters

    # get part of the image where the char location is at
    for char_loc in char_locs:
        (x, y, width, height) = char_loc

        roi = word_img[y:y + height, x:x + width]
        roi = cv2.resize(roi, (28, 28))
        char_images.append(roi)

    char_images = numpy.array(char_images)

    # reshaping
    char_images = char_images.reshape(-1, 28, 28, 1)

    classifications = model.predict(char_images)

    for i, classification in enumerate(classifications):
        if i != 0:  # if its less likely its a capital letter
            # for each capital letter
            for class_index in range(get_label_classification('A'), get_label_classification('Z') + 1):
                classifications[i][class_index] = classifications[i][class_index] / 6  # lower the score

        result = numpy.argmax(classification)
        word_output += get_label_char(result)
        # if the next character is too far from this current one
        if i < len(classifications) - 1 \
           and char_locs[i][X] + char_locs[i][WIDTH] + avg_loc_width // 2 < char_locs[i + 1][X]:
            word_output += ' '

    return word_output

