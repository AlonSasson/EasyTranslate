import cv2
import numpy
import imutils
from PIL import ImageFont, ImageDraw, Image


def blur_locations(image, locations):
    for loc in locations:
        (x, y, w, h) = loc
        roi = image[y:y+h, x:x+w]  # seperate the roi
        blur = cv2.GaussianBlur(roi, (51, 51), 0)  # apply a gaussian blur filter
        image[y:y+h, x:x+w] = blur  # insert the blurred roi back into the image
    return image


def place_text_in_locs(image, locations, text):
    text = 'השועל המהיר והחום קופץ מעל הכלב העצל'[::-1]
    words = text.split()
    for i, loc in enumerate(locations):
        if i >= len(words):
            break
        (x, y, width, height) = loc
        roi = image[y:y+height, x:x+width]
        roi_pil = Image.fromarray(roi)
        image_pil = Image.fromarray(image)
        draw = ImageDraw.Draw(image_pil)
        font_size = 1
        font = ImageFont.truetype("arial.ttf", font_size)
        jump_size = 75
        while True:  # finding the right font size using binary search
            if font.getsize(words[i])[0] < roi_pil.size[0]: # if the text font is still small
                font_size += jump_size
            else:  # if the text size is too big
                jump_size = jump_size // 2
                font_size -= jump_size
            font = ImageFont.truetype("arial.ttf", font_size)
            if jump_size <= 1:  # if we found the correct font size
                break
        font_size -= 1
        font = ImageFont.truetype("arial.ttf", font_size)
        print(font_size)
        draw.text((x, y - height // 5), words[i], font=font, fill=(0, 0, 0))
        image = numpy.array(image_pil)
    return image


def main():
    pass


if __name__ == "__main__":
    main()