import cv2
import TextReplacement
import ImageProcessing as ip
import Translate
import VideoProcessing



def translate_image(image):
    """ Translates the text in an image
    :param image: the image to translate
    :return: the translated image
    """
    char_templates = ip.get_character_dict()  # get a dictionary of all the character templates
    if image is None:
        return
    image, thresh, locations = ip.get_text_locations(image)  # get the word locations in the image
    text = ''
    for word_loc in locations:
        (x, y, width, height) = word_loc
        word_img = image[y:y + height, x:x + width]  # get an image of just the word
        word_img, char_locs = ip.get_image_contours(word_img)  # get the character locations from that image
        word_output = ip.get_word_with_char_locations(word_img, char_locs,
                                                      char_templates)  # get the word from the image
        if word_output != '':
            cv2.rectangle(image, (x, y),
                          (x + width, y + height), (0, 0, 255), 2)
            cv2.putText(image, word_output, (x, y + height + 10),
                        cv2.FONT_HERSHEY_SIMPLEX, 0.65, (0, 0, 255), 2)
            text += word_output + ' '
    text = text.lower()
    text, right_left = Translate.googletrans_translate(text, 'he')
    image = ip.blur_locations(image, locations)
    image = TextReplacement.place_text_in_locs(image, locations, text, right_left)
    #cv2.imshow("Image", thresh)
    #cv2.imshow("Image2", image)
    #cv2.waitKey(0)
    return image


def translate_video(video_path):
    """ translates a video
    :param video_path: the video to translate
    """
    out_path = video_path.split(".", -1)
    out_path = out_path[0] + '_translated.avi'
    VideoProcessing.process_video(video_path, out_path, translate_image)
    VideoProcessing.copy_video_sound(video_path, out_path, out_path)


def main():
    #image = cv2.imread(r'test2.jpg')  # Read the file
    #translate_image(image)
    translate_video('project_present.avi')


if __name__ == "__main__":
    main()
