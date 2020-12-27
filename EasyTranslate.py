import cv2
import numpy
import imutils
import functools
from datetime import datetime

X = 0
Y = 1
WIDTH = 2
HEIGHT = 3


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
    AVG_LOC_SIZE = get_average_loc_area(locations)
    AVG_LOC_HEIGHT = get_average_loc_height(locations)
    while i < len(locations):
        if loc_area(locations[i]) < AVG_LOC_SIZE / 2:  # if the location is smaller than average
            for j in range(i+1, len(locations)):
                # if they are in same col and close enough
                if (are_locs_in_same_col(locations[i], locations[j])
                   and locations[i][Y] + locations[i][HEIGHT] + AVG_LOC_HEIGHT / 2 > locations[j][Y]):
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
    AVG_LOC_SIZE = get_average_loc_area(locations)
    AVG_LOC_WIDTH = get_average_loc_height(locations)
    AVG_LOC_HEIGHT = get_average_loc_height(locations)
    for i in range(len(locations)):
        if loc_area(locations[i]) < AVG_LOC_SIZE / 2:  # if the location is smaller than average
            # make them a bit bigger
            locations[i] = [locations[i][X] - int(AVG_LOC_WIDTH / 5), locations[i][Y] - int(AVG_LOC_HEIGHT / 5),
                            locations[i][WIDTH] + int(AVG_LOC_WIDTH / 5) * 2,
                            locations[i][HEIGHT] + int(AVG_LOC_HEIGHT / 5) * 2]
            if locations[i][X] < 0:  # if we are out of the frame in the x axis
                locations[i][X] = 0
                locations[i][WIDTH] -= int(AVG_LOC_WIDTH / 5)
            if locations[i][Y] < 0:  # if we are out of the frame in the y axis
                locations[i][Y] = 0
                locations[i][HEIGHT] -= int(AVG_LOC_WIDTH / 5)
    return locations


def cmp_locs(loc1, loc2):
    """ compares two locations to determine which should be before the other
    :param loc1 - a location
    :param loc2 - a location
    :return -1 - if loc1 should be before loc2, return 1 otherwise
    """
    # if loc1 is above loc2 or in the same row but further to the left
    if loc1[Y] + loc1[HEIGHT] < loc2[Y] or (loc1[Y] < loc2[Y] + loc2[HEIGHT] and loc1[X] < loc2[X]):
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
        if locations[i][Y] + locations[i][HEIGHT] > locations[i+1][Y] \
         and locations[i][X] + locations[i][WIDTH] + threshold > locations[i + 1][X]:
            locations[i] = union_two_rects(locations[i], locations[i + 1])  # merge them
            locations.remove(locations[i+1])
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
    thresh = cv2.threshold(grayscale, 0, 255, cv2.THRESH_BINARY_INV | cv2.THRESH_OTSU)[1]  # apply filters
    ref_cnts, heirarchy = cv2.findContours(thresh, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)  #find the contours
    locations = []
    for (i, cnt) in enumerate(ref_cnts):  # put the contours into a list of locations
        (x, y, w, h) = cv2.boundingRect(cnt)
        locations.append([x, y, w, h])
    if not locations:  # if no locations were found
        return thresh, locations
    locations = enlarge_small_locs(locations)
    locations = merge_overlapping_locs(locations)
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs))  # sort after merging
    locations = merge_small_locs(locations)
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs))  # sort again after merging
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
    #find the contours in the image
    word_cnts = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    word_cnts = imutils.grab_contours(word_cnts)
    locations = []
    for cnt in word_cnts:  # put the contours into a list of locations
        (x, y, width, height) = cv2.boundingRect(cnt)
        locations.append((x, y, width, height))
    locations = enlarge_small_locs(locations)
    locations = merge_overlapping_locs(locations)
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs))  # sort after merging
    locations = merge_close_locs(locations, 5)
    locations = merge_small_locs(locations)
    locations = sorted(locations, key=functools.cmp_to_key(cmp_locs))  # sort again after merging
    return image, thresh, locations


def get_word_with_char_locations(word_img, char_locs, char_templates):
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


def main():
    char_templates = get_character_dict()  # get a dictionary of all the character templates
    start = datetime.now()
    image = cv2.imread(r'font2.jpg')  # Read the file
    if image is None:
        return
    image, thresh, locations = get_text_locations(image)  # get the word locations in the image
    for word_loc in locations:
        word_output = ''
        (x, y, width, height) = word_loc
        word_img = image[y:y + height, x:x + width]  # get an image of just the word
        word_img, char_locs = get_image_contours(word_img)  # get the character locations from that image
        word_output = get_word_with_char_locations(word_img, char_locs, char_templates)  # get the word from the image
        if word_output != '':
            cv2.rectangle(image, (x, y),
                          (x + width, y + height), (0, 0, 255), 2)
            cv2.putText(image, word_output, (x, y + height + 10),
                        cv2.FONT_HERSHEY_SIMPLEX, 0.65, (0, 0, 255), 2)
            print(word_output)
    end = datetime.now()
    print(end - start)
    cv2.imshow("Image", thresh)
    cv2.imshow("Image2", image)
    cv2.waitKey(0)


if __name__ == "__main__":
    main()