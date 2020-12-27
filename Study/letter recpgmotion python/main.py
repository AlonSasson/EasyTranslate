import numpy as np 
import cv2 
import os
import functools


X = 0
Y = 1
WIDTH = 2
HEIGHT = 3


def cmp_locs(loc1, loc2):
    if loc1[Y] + loc1[HEIGHT] < loc2[Y] or (loc1[Y] < loc2[Y] + loc2[HEIGHT] and loc1[X] < loc2[X]):  # if the locs need to be swapped
        return -1
    return 1


def merge_overlapping_locs(locations):
    i = 0
    while i < len(locations) - 1:
        j = i + 1
        while j < len(locations):
            intersection_rect = intersection_two_rects(locations[i], locations[j])
            if intersection_rect[WIDTH] * intersection_rect[HEIGHT] > 0:  # if the two locations overlap
                locations[i] = union_two_rects(locations[i], locations[j])  # merge them
                locations.remove(locations[j])
                j = i  # reset to see if the rectangle needs more merging
            j += 1
        i += 1
    return locations


def merge_close_locs(locations):
    i = 0
    while i < len(locations) - 1:
        # if the two rectangles are in the same "line" and are close enough
        if locations[i][Y] + locations[i][HEIGHT] > locations[i+1][Y] \
         and locations[i][X] + locations[i][WIDTH] + 11 > locations[i + 1][X]:
            locations[i] = union_two_rects(locations[i], locations[i + 1])  # merge them
            locations.remove(locations[i+1])
            i = - 1 # reset to see if some rectangle needs more merging
        i += 1
    return locations


def union_two_rects(rect1, rect2):
    x = min(rect1[X], rect2[X])
    y = min(rect1[Y], rect2[Y])
    width = max(rect1[X] + rect1[WIDTH], rect2[X] + rect2[WIDTH]) - x
    height = max(rect1[Y] + rect1[HEIGHT], rect2[Y] + rect2[HEIGHT]) - y
    return (x, y, width, height)


def intersection_two_rects(rect1, rect2):
    x = max(rect1[X], rect2[X])
    y = max(rect1[Y], rect2[Y])
    width = min(rect1[X] + rect1[WIDTH], rect2[X] + rect2[WIDTH]) - x
    height = min(rect1[Y] + rect1[HEIGHT], rect2[Y] + rect2[HEIGHT]) - y
    if width < 0 or height < 0:
        return (0, 0, 0, 0)  # null rect
    return (x, y, width, height)

def found_hige_hierachy(contours, hierarchy, img_path):
    
    img_contours = cv2.imread(img_path)
    
    #rect = cv2.cv2.boundingRect(contour) # init varubl
    rectsCharVecotr = []
    
    #out all good countor
    for i in range(len(contours)):

        x,y,w,h = cv2.boundingRect(contours[i])
        
        if hierarchy[i][3] != -1: # 3 is the hirechy index
            rectsCharVecotr.append((x,y,w,h))
            cv2.rectangle(img_contours, (x,y),(x+w,y+h), (255,0,0), 0)  # drow the good hireacrhy in blue
        else:
            cv2.rectangle(img_contours, (x,y),(x+w,y+h), (0,0,255), 2)  # drow the bad hireacrhy in red

    #show the image
    cv2.imshow("Contours", img_contours)
    return rectsCharVecotr

def template_machine(rectsCharVecotr, img_filter, latter_to_recognize): #when we have the dicanry we need to fix 
    scores = {}

    #pass all image 
    for i in range(len(rectsCharVecotr)):
        #cut the image
        x,y,w,h = rectsCharVecotr[i]  # get image xy and witht higth 
        char_of_word_image = img_filter[y:y+h, x:x+w]
        
        #resize image
        char_of_word_image = cv2.resize(char_of_word_image, (57, 88))


        result = cv2.matchTemplate(latter_to_recognize, char_of_word_image, cv2.TM_CCOEFF)
        (_, score, _, _) = cv2.minMaxLoc(result)
        scores[score] = char_of_word_image
        #show all image he pass
        cv2.imshow("letter to check", char_of_word_image)
        cv2.waitKey(0) 
        cv2.destroyWindow("letter to check") 

    return scores

def get_letter_by_path(path):
    pass
    """
    latter_to_recognize = cv2.imread(path)
    #filter
    latter_to_recognize = cv2.cvtColor(latter_to_recognize, cv2.COLOR_BGR2GRAY)
    latter_to_recognize = cv2.threshold(latter_to_recognize, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]

    #found contours
    contours, hierarchy = cv2.findContours(latter_to_recognize, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

    hierarchy = hierarchy[0]

    rect_letter = dound_hige_hierachy(contours, hierarchy, path)[0]
    """
    #magre close rect 
    #latter_to_recognize = merge_overlapping_locs(latter_to_recognize)

    #sort
    #latter_to_recognize = sorted(latter_to_recognize, key=functools.cmp_to_key(cmp_locs))

    #latter_to_recognize = cv2.resize(latter_to_recognize, (57,88))
    #cv2.imshow("char to recognize", latter_to_recognize[rect])
    #cv2.waitKey()


latter_to_recognize = cv2.imread("n.jpg")

#filter
latter_to_recognize = cv2.cvtColor(latter_to_recognize, cv2.COLOR_BGR2GRAY)
latter_to_recognize = cv2.threshold(latter_to_recognize, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]
latter_to_recognize = cv2.resize(latter_to_recognize, (57,88))
cv2.imshow("char to recognize", latter_to_recognize)

#get all file from directory
fonts = os.listdir("fonts/")

for font_path in fonts:
    font_path = "fonts/" + font_path
    #read the image
    img_vanila = cv2.imread(font_path)
    img_contours = cv2.imread(font_path)
    img_filter = cv2.imread(font_path)

    cv2.imshow(font_path, img_vanila)


    #find contours and hierachy #filter
    img_filter = cv2.cvtColor(img_vanila, cv2.COLOR_BGR2GRAY)
    img_filter = cv2.threshold(img_filter, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]
    contours, hierarchy = cv2.findContours(img_filter, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

    # find only letter by hiercy
    hierarchy = hierarchy[0] # get the actual inner list of hierarchy descriptions

    rectsCharVecotr = found_hige_hierachy(contours, hierarchy, font_path)
    
    #magre close rect 
    rectsCharVecotr = merge_overlapping_locs(rectsCharVecotr)

    #sort
    rectsCharVecotr = sorted(rectsCharVecotr, key=functools.cmp_to_key(cmp_locs))

    # template matching scores	
    scores = template_machine(rectsCharVecotr, img_filter, latter_to_recognize)

    #show the muching latter
    max_key = max(scores.keys())
    img = scores[max_key]
    cv2.imshow("good latter", img)
    cv2.waitKey(0) 

    #close all image 
    cv2.waitKey(0) 
    cv2.destroyAllWindows() 
