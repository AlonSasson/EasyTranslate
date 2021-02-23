import cv2
import numpy
import functools
import tensorflow as tf
import Translate
import TextReplacement
from imutils.object_detection import non_max_suppression
from threading import Lock
import pytesseract
from pytesseract import Output
import pathlib


X = 0
Y = 1
WIDTH = 2
HEIGHT = 3

net_lock = Lock()

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


def cmp_rect_same_lines(rec1, rec2):
    """
    check if this 2 rect in the same line
    :param num1: (x, y, h, w)
    :param num2: (x, y, h, w)
    :return: bool if it true
    """
    # get the 50% of the avrage high
    average_high = (rec1[HEIGHT] + rec2[HEIGHT]) // 2
    average_high *= 0.5
    return (rec1[Y] + average_high >= rec2[Y] and rec1[Y] - average_high <= rec2[Y])


def cmp_locs_left_right(loc1, loc2):
    """ compares two locations to determine which should be before the other going from left to right
    :param loc1 - a location
    :param loc2 - a location
    :return -1 - if loc1 should be before loc2, return 1 otherwise
    """
    if (cmp_rect_same_lines(loc1, loc2)):
        if  loc1[X] < loc2[X]:
            return -1
        else:
            return 1

    if loc1[Y] < loc2[Y]:
        return -1
    else:
        return 1



def cmp_locs_right_left(loc1, loc2):
    """ compares two locations to determine which should be before the other going from right to left
    :param loc1 - a location
    :param loc2 - a location
    :return -1 - if loc1 should be before loc2, return 1 otherwise
    """
    if (cmp_rect_same_lines(loc1, loc2)):
        if loc1[X] > loc2[X]:
            return -1
        else:
            return 1

    if loc1[Y] < loc2[Y]:
        return -1
    else:
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
    if "model" not in east_get_text_locations.__dict__:  # initialize the net
        east_get_text_locations.net = cv2.dnn.readNet(str(pathlib.Path(__file__).parent.absolute()) + r'\east_model\frozen_east_text_detection.pb')
    # resize the image and grab the new image dimensions
    thresh = cv2.resize(image, (640, 320))
    (oldH, oldW) = image.shape[:2]
    (H, W) = thresh.shape[:2]
    (rH, rW) = oldH/H, oldW/W  # save the old and new height and width ratio

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

    east_get_text_locations.net.setInput(blob)

    net_lock.acquire()  # lock before using the shared net
    (scores, geometry) = east_get_text_locations.net.forward(layer_names)  # get text locations and scores
    net_lock.release()  # release lock

    # get the locations from the net output
    (rects, confidences) = get_locations_from_net_results(scores, geometry, min_confidence)

    # apply non-maxima suppression to suppress weak, overlapping bounding
    # boxes
    boxes = non_max_suppression(numpy.array(rects), probs=confidences)

    # loop over the bounding boxes
    for i, (startX, startY, endX, endY) in enumerate(boxes):
        startX *= rW
        endX *= rW
        startY *= rH
        endY *= rH
        boxes[i] = [startX, startY, endX - startX, endY - startY]  # use width and height instead of end points
        boxes[i] = enlarge_loc(boxes[i], 0, int(boxes[i][HEIGHT] / 10))  # enlarge the boxes by a bit to reduce errors

    locations = sorted(boxes, key=functools.cmp_to_key(cmp_locs_left_right))  # sort the locations

    return image, thresh, locations


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
    :return the word that was found in the image
    """
    if "model" not in get_word_ml.__dict__:  # initialize the model
        get_word_ml.model = tf.keras.models.load_model(str(pathlib.Path(__file__).parent.absolute()) + r'/my_model')

    char_images = []
    word_output = ''

    if not char_locs:
        return word_output
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

    classifications = get_word_ml.model.predict(char_images)

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


def translate_image(image):
    """ Translates the text in an image
    :param image: the image to translate
    :return: the translated image, and the text locations in the image
    """
    if image is None:
        return image, []

    image, thresh, locations = east_get_text_locations(image, 0.2)  # get the word locations in the image

    text = []
    for word_loc in locations:
        (x, y, width, height) = word_loc
        word_img = image[y:y + height, x:x + width]  # get an image of just the word
        _, char_locs = get_image_contours(word_img)  # get the character locations from that image
        word_output = get_word_ml(word_img, char_locs)
        for loc in char_locs:
            (x1, y1, width1, height1) = loc
            """cv2.rectangle(image, (x+x1, y+y1),
                          (x+x1 + width1, y+y1 + height1), (0, 255, 0), 2)"""

        if word_output != '':
            text.append(word_output + ' ')

    for i, word_loc in enumerate(locations):  # create a bounding box with text
        (x, y, width, height) = word_loc
        """cv2.rectangle(image, (x, y),
                      (x + width, y + height), (0, 0, 255), 2)
        cv2.putText(image, text[i], (x, y + height + 10),
                    cv2.FONT_HERSHEY_SIMPLEX, 0.65, (0, 0, 255), 2)"""

    text = ''.join(text).lower()

    text, right_left = Translate.googletrans_translate(text, 'HE')
    image = blur_locations(image, locations)
    image = TextReplacement.place_text_in_locs(image, locations, text, right_left)

    return image, locations


#----------------------------------------------------tessaract
#using east_get_text_locations function

def get_contour_precedence(contour, cols):
    tolerance_factor = 10
    origin = cv2.boundingRect(contour)
    return ((origin[1] // tolerance_factor) * tolerance_factor) * cols + origin[0]

def find_sentences_tesseract(img):
    """
    the function get image and return a dict withe word in image and location
    :param img: cv2 of image
    :return: dict [word] = location of word [x, y, w, h]
    """
    bla = img
    img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    img = cv2.threshold(img, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)[1]

    config = '--psm 8'
    d = pytesseract.image_to_data(img, output_type=Output.DICT, config=config)

    word = d['text']

    sentences_in_image = {}
    word_num_check = 0
    sentence = ""
    x, y, w, h, check_line = 0, 0, 0, 0, 0

    n_boxes = len(d['text'])
    for i in range(n_boxes):
        d['text'][i] = ''.join(filter(str.isalpha, d['text'][i]))
        if (d['text'][i] != ''):  # check if the text is not empty
            word = d['text'][i]

    return word

def translate_image_tess(image):
    """
    get image and return image withe the translate of the text in the image
    :param image: image of opencv2
    :return: image of opencv2
    """
    if image is None:
        return image, []

    #get the location of text using east
    image, thresh, locations = east_get_text_locations(image, 0.2)  # get the word locations in the image

    words = []
    indexs = []

    #undestend the word text using tess
    for i, word_loc in enumerate(locations):
        (x, y, width, height) = word_loc
        word_img = image[y:y + height, x:x + width]  # get an image of just the word

        new_word = find_sentences_tesseract(word_img)
        if (new_word != ""):
            words.append(new_word)
        else:
            indexs.append(i)


    for count, i  in enumerate(indexs):
        locations.pop(i - count)

    # blur the locations of the text
    image = blur_locations(image, locations)

    lines_of_location = {}
    line_text = ''
    new_line = []

    #splite the location and text to line
    for i, location in enumerate(locations):
        if not new_line: # check if it is the first item in list
            new_line.append(location)
            line_text += words[i] + " "
        else:
            if (cmp_rect_same_lines(new_line[-1], location)): #check if in the smae line
                new_line.append(location)
                line_text += words[i] + " "
            else:
                lines_of_location[line_text] = new_line
                new_line = []
                new_line.append(location)
                line_text = words[i] + " "
        #Adding check on x scale

        if (numpy.array_equal(locations[-1], location)): # it means the last word
            lines_of_location[line_text] = new_line


    #Translate the sentence
    for  text_line in lines_of_location:
        translate_sentence, right_left = Translate.googletrans_translate(text_line, 'HE')
        image = TextReplacement.place_text_in_locs(image, lines_of_location[text_line], translate_sentence, right_left)  # right_left)


    # draw the sentence in the image

    return image, locations
