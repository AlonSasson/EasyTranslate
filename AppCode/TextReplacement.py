import cv2
import numpy
import ImageProcessing as ip
import functools
import math
from PIL import ImageFont, ImageDraw, Image


def get_max_font_size(font_name, text, image):
    """
    gets the max font size using font_name and text without exceeding the image's boundries
    :param font_name: a font name
    :param text: the text which we try to fit in image
    :param image: a pillow image
    :return: the max font size in which text can fit in image perfectly
    """
    font_size = 1
    font = ImageFont.truetype(font_name, font_size)
    jump_size = 75
    while True:  # finding the right font size using binary search
        if font.getsize(text)[0] < image.size[0]:  # if the text font is still small
            font_size += jump_size
        else:  # if the text size is too big
            jump_size = jump_size // 2
            font_size -= jump_size
        font = ImageFont.truetype(font_name, font_size)
        if jump_size <= 1:  # if we found the correct font size
            return font_size - 1  # remove one so the text still fits


def devide_text_between_locations(words, locations):
    """ devide the words into the locations correctly (a certain amount of words per location)
    :param words: a list of words
    :param locations: the locations we need to devide the words between
    :return: the words list after deviding them correctly per location
    """
    words_count = len(words)
    for i in range(len(locations)):
        for j in range(1, math.ceil(words_count / (len(locations) - i))):  # calcualte how many words we need to join
            words[i] += ' ' + words[i + 1]  # join the next word
            words.remove(words[i + 1])  # delete the next word
        words_count -= math.ceil(words_count / (len(locations) - i)) # remove the amount of words we joined from the total count
    return words


def place_text_in_locs(image, locations, text, right_left=False):
    """ places text in an image in certain locations
    :param image: the image we want to write text on
    :param locations: the locations in which we need to write text
    :param text: the text we need to write
    :param right_left: a flag that determines whether the text should be written from right to left
    :return: the processed image with the text in it
    """
    words = text.split()
    if right_left:  # if the text should be written from right to left
        text = text[::-1]
        locations = sorted(locations, key=functools.cmp_to_key(ip.cmp_locs_right_left))  # sort from right to left
        words = text.split()[::-1]

    words = devide_text_between_locations(words, locations)
    for i, loc in enumerate(locations):
        if i >= len(words):
            break
        (x, y, width, height) = loc
        roi = image[y:y+height, x:x+width]
        roi_pil = Image.fromarray(roi)  # convert the roi and image to pillow images
        image_pil = Image.fromarray(image)
        draw = ImageDraw.Draw(image_pil)
        font_size = get_max_font_size("arial.ttf", words[i], roi_pil)  # get the max font size for that roi
        font = ImageFont.truetype("arial.ttf", font_size)
        draw.text((x, y + height - font.getsize(words[i])[1]), words[i], font=font, fill=(0, 0, 0))  # draw the text in the correct location
        image = numpy.array(image_pil)
    return image
