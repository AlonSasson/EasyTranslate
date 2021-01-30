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

    if image is None:
        return

    image, thresh, locations = ip.east_get_text_locations(image, 0.2)  # get the word locations in the image
    text = []
    for word_loc in locations:
        (x, y, width, height) = word_loc
        word_img = image[y:y + height, x:x + width]  # get an image of just the word
        _, char_locs = ip.get_image_contours(word_img)  # get the character locations from that image
        word_output = ip.get_word_ml(word_img, char_locs)

        if word_output != '':
            text.append(word_output + ' ')

    for i, word_loc in enumerate(locations):  # create a bounding box with text
        (x, y, width, height) = word_loc
        cv2.rectangle(image, (x, y),
                      (x + width, y + height), (0, 0, 255), 2)
        cv2.putText(image, text[i], (x, y + height + 10),
                    cv2.FONT_HERSHEY_SIMPLEX, 0.65, (0, 0, 255), 2)

    text = ''.join(text).lower()
    print(text)

    #text, right_left = Translate.googletrans_translate(text, 'en')
    #image = ip.blur_locations(image, locations)
    #image = TextReplacement.place_text_in_locs(image, locations, text, right_left)

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
    #image = cv2.imread("test2.jpg")  # Read the file
    #translate_image(image)
    translate_video('project_present.mp4')


if __name__ == "__main__":
    main()
