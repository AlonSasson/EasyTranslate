import cv2
import ImageProcessing as ip
import VideoProcessing as vp
import time
import sys
import os
from enum import Enum
from deep_translator import GoogleTranslator


class Choice(Enum):
    # choose platform
    IMAGE = "image"
    VIDEO = "video"
    SCREEN = "screen"
    PART_OF_SCREEN = "part_of_screen"

    # choose function
    TESSERACT = "tesseract"
    TENSORFLOW = "tensorflow"


def translate_image(image_path, save_path, dest_language, translation_function):
    """ Translates the text in an image and saves it
    :param image_path: the path of the image to translate
    :param save_path: the path to save the image at
    :param dest_language: the language to translate the image to
    :param translation_function: the function to use to translate the image
    """
    image = cv2.imread(image_path)  # Read the image
    if image is None:
        print("Image was not found")
        return
    start_time = time.time()
    thresh, _ = translation_function(image, dest_language)
    print("--- %s seconds ---" % (time.time() - start_time))

    cv2.imwrite(save_path, thresh)


def translate_video(video_path, out_path, dest_language, translation_function=ip.translate_image_tf):
    """ translates a video
    :param video_path: the video to translate
    :param out_path: the path to save the translated video at
    :param dest_language: the language to translate the video to
    :param translation_function: the function to use to translate the video with
    """
    # output the video to a temp file first, for when the video clip path and the out path are the same
    temp_path = out_path.split('.', -1)[0]  # get the out path without the file type
    temp_path += '_temp.mp4'

    vp.translate_video(video_path, temp_path, dest_language, translation_function)
    vp.copy_video_sound(video_path, temp_path, out_path)

    os.remove(temp_path)  # remove the temp file


def main():
    platform_choice = sys.argv[1]
    translate_function = sys.argv[2]
    dest_language = sys.argv[3]

    if dest_language not in GoogleTranslator.get_supported_languages():
        print("Invalid option. valid options are:", ", ".join(GoogleTranslator.get_supported_languages()))
        return -1

    # choosing the function of translate
    if translate_function == Choice.TESSERACT.value:
        translate_function = ip.translate_image_tess
    elif translate_function == Choice.TENSORFLOW.value:
        translate_function = ip.translate_image_tf
    else:
        print("Invalid option. valid options are: tesseract, tensorflow")
        return -1

    # choosing platform

    if platform_choice == Choice.IMAGE.value:
        translate_image(sys.argv[4], sys.argv[5], dest_language, translate_function)

    elif platform_choice == Choice.VIDEO.value:
        translate_video(sys.argv[4], sys.argv[5], dest_language, translate_function)

    elif platform_choice == Choice.SCREEN.value:
        vp.translate_screen(dest_language, translate_function=translate_function)

    elif platform_choice == Choice.PART_OF_SCREEN.value:
        vp.translate_screen(dest_language, vp.select_area(), translate_function)

    else:
        print("Invalid option. valid options are: image, video, screen, part_of_screen")
        return -1


if __name__ == "__main__":
    main()
