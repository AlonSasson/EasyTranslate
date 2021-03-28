import cv2
import ImageProcessing as ip
import VideoProcessing as vp
import time
import sys
import os
from enum import Enum


class Choice(Enum):
    IMAGE_TRANSLATE_TESS = "0"
    IMAGE_TRANSLATE_TENSORFLOW = "1"
    VIDEO_TRANSLATE_TESS = "2"
    VIDEO_TRANSLATE_TENSORFLOW = "3"
    REAL_TIME = "4"
    REAL_TIME_PART = "5"


def translate_image(image_path, save_path, filter_function):
    """ Translates the text in an image
    :param image_path: the path of the image to translate
    :return: the translated image
    """
    image = cv2.imread(image_path)  # Read the image
    if image is None:
        print("Image was not found")
        return
    start_time = time.time()
    thresh, _ = filter_function(image)
    print("--- %s seconds ---" % (time.time() - start_time))

    cv2.imwrite(save_path, thresh)



def translate_video(video_path, out_path, filter_function = ip.translate_image):
    """ translates a video
    :param video_path: the video to translate
    """
    # output the video to a temp file first, for when the video clip path and the out path are the same
    temp_path = out_path.split('.', -1)[0]  # get the out path without the file type
    temp_path += '_temp.mp4'

    vp.process_video(video_path, temp_path, filter_function)
    vp.copy_video_sound(video_path, temp_path, out_path)

    os.remove(temp_path)  # remove the temp file

def main():

    function_choice = sys.argv[1]

    if function_choice == Choice.IMAGE_TRANSLATE_TESS.value:
        translate_image(sys.argv[2], sys.argv[3], ip.translate_image_tess)

    elif function_choice == Choice.IMAGE_TRANSLATE_TENSORFLOW.value:
        translate_image(sys.argv[2], sys.argv[3], ip.translate_image)

    elif function_choice == Choice.VIDEO_TRANSLATE_TESS.value:
        translate_video(sys.argv[2], sys.argv[3], ip.translate_image_tess)

    elif function_choice == Choice.VIDEO_TRANSLATE_TENSORFLOW.value:
        translate_video(sys.argv[2], sys.argv[3], ip.translate_image)

    elif function_choice == Choice.REAL_TIME.value:
        vp.translate_screen(translate_function=ip.translate_image_tess)

    elif function_choice == Choice.REAL_TIME_PART.value:
        vp.translate_screen(vp.select_area(), ip.translate_image_tess)


if __name__ == "__main__":
    main()
