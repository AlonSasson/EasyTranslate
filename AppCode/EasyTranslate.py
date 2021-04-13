import cv2
import ImageProcessing as ip
import VideoProcessing as vp
import time
import sys
import os
from enum import Enum


class Choice(Enum):
    # choose platform
    IMAGE = "image"
    VIDEO = "video"
    SCREEN = "screen"
    PART_OF_SCREEN = "part_of_screen"

    # choose function
    TESSERACT = "tesseract"
    TENSORFLOW = "tensorflow"


def translate_image(image_path, save_path, translation_function):
    """ Translates the text in an image
    :param image_path: the path of the image to translate
    :param save_path: the path to save the image at
    :param translation_function: the function to use to translate the image
    :return: the translated image
    """
    image = cv2.imread(image_path)  # Read the image
    if image is None:
        print("Image was not found")
        return
    start_time = time.time()
    thresh, _ = translation_function(image)
    print("--- %s seconds ---" % (time.time() - start_time))

    cv2.imwrite(save_path, thresh)


def translate_video(video_path, out_path, translation_function=ip.translate_image_tf):
    """ translates a video
    :param video_path: the video to translate
    :param out_path: the path to save the translated video at
    :param translation_function: the function to use to translate the video with
    """
    # output the video to a temp file first, for when the video clip path and the out path are the same
    temp_path = out_path.split('.', -1)[0]  # get the out path without the file type
    temp_path += '_temp.mp4'

    vp.process_video(video_path, temp_path, translation_function)
    vp.copy_video_sound(video_path, temp_path, out_path)

    os.remove(temp_path)  # remove the temp file


def main():
    platform_choice = sys.argv[1]
    translate_function = sys.argv[2]

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
        translate_image(sys.argv[3], sys.argv[4], translate_function)

    elif platform_choice == Choice.VIDEO.value:
        translate_video(sys.argv[3], sys.argv[4], translate_function)

    elif platform_choice == Choice.SCREEN.value:
        vp.translate_screen(translate_function=translate_function)

    elif platform_choice == Choice.PART_OF_SCREEN.value:
        vp.translate_screen(vp.select_area(), translate_function)

    else:
        print("Invalid option. valid options are: image, video, screen, part_of_screen")
        return -1


if __name__ == "__main__":
    main()
