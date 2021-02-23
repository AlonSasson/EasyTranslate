import cv2
import ImageProcessing as ip
import VideoProcessing as vp
import time
import sys
from enum import Enum


class Choice(Enum):
    IMAGE_TANSLATE_TESS = "0"
    IMAGE_TANSLATE_TENSARFLOW = "1"
    VIDEO_TANSLATE_TESS = "2"
    VIDEO_TANSLATE_TENSARFLOW = "3"
    REAL_TIME = "4"



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

    vp.process_video(video_path, out_path, filter_function)
    vp.copy_video_sound(video_path, out_path, out_path)


def main():

    function_choice = sys.argv[1]

    if   (function_choice == Choice.IMAGE_TANSLATE_TESS.value):
        translate_image(sys.argv[2], sys.argv[3], ip.translate_image_tess)

    elif (function_choice == Choice.IMAGE_TANSLATE_TENSARFLOW.value):
        translate_image(sys.argv[2], sys.argv[3], ip.translate_image)

    elif (function_choice == Choice.VIDEO_TANSLATE_TESS.value):
        translate_video(sys.argv[2], sys.argv[3], ip.translate_image_tess)

    elif (function_choice == Choice.VIDEO_TANSLATE_TENSARFLOW.value):
        translate_video(sys.argv[2], sys.argv[3], ip.translate_image)

    elif (function_choice == Choice.REAL_TIME.value):
        pass

    #translate_image(sys.argv[1], sys.argv[2])
    #ip.translate_image_tess(cv2.imread("testing/image.jpg"))
    #translate_video(sys.argv[1], sys.argv[2], ip.translate_image_tess)
    #vp.translate_screen(vp.select_area())

if __name__ == "__main__":
    main()
