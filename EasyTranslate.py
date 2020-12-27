import cv2
import TextReplacement
import ImageProcessing as ip
import Translate
from datetime import datetime


def main():
    char_templates = ip.get_character_dict()  # get a dictionary of all the character templates
    start = datetime.now()
    image = cv2.imread(r'test2.jpg')  # Read the file
    if image is None:
        return
    image, thresh, locations = ip.get_text_locations(image)  # get the word locations in the image
    text = ''
    for word_loc in locations:
        (x, y, width, height) = word_loc
        word_img = image[y:y + height, x:x + width]  # get an image of just the word
        word_img, char_locs = ip.get_image_contours(word_img)  # get the character locations from that image
        word_output = ip.get_word_with_char_locations(word_img, char_locs, char_templates)  # get the word from the image
        if word_output != '':
            cv2.rectangle(image, (x, y),
                          (x + width, y + height), (0, 0, 255), 2)
            cv2.putText(image, word_output, (x, y + height + 10),
                        cv2.FONT_HERSHEY_SIMPLEX, 0.65, (0, 0, 255), 2)
            text += word_output + ' '
    print(text)
    text, right_left = Translate.translate_post(text, 'iw')
    image = TextReplacement.blur_locations(image, locations)
    image = TextReplacement.place_text_in_locs(image, locations, text, right_left)
    end = datetime.now()
    print(end - start)
    cv2.imshow("Image", thresh)
    cv2.imshow("Image2", image)
    cv2.waitKey(0)


if __name__ == "__main__":
    main()
