import cv2
import ImageProcessing as ip
import VideoProcessing as vp
import time


def translate_image(image_path):
    """ Translates the text in an image
    :param image_path: the path of the image to translate
    :return: the translated image
    """
    image = cv2.imread(image_path)  # Read the image
    if image is None:
        print("Image was not found")
        return
    thresh, _ = ip.translate_image(image)
    cv2.imshow("Thresh", thresh)
    cv2.imshow("Image", image)
    cv2.waitKey(0)


def translate_video(video_path):
    """ translates a video
    :param video_path: the video to translate
    """
    out_path = video_path.split(".", -1)
    out_path = out_path[0] + '_translated.avi'
    vp.process_video(video_path, out_path, translate_image)
    vp.copy_video_sound(video_path, out_path, out_path)


def main():
    #translate_image("testing/test2.jpg")
    #translate_video('testing/project_present.avi')
    vp.translate_screen()

if __name__ == "__main__":
    main()
