import cv2
import moviepy.editor as mp
import sys
from PyQt5 import QtWidgets, QtCore


class SelectWindow(QtWidgets.QMainWindow):

    selected_area = []

    def __init__(self):
        QtWidgets.QMainWindow.__init__(self)

        self.setWindowOpacity(0.3)  # set the overlay opacity
        self.setWindowFlags(
            QtCore.Qt.WindowStaysOnTopHint |  # make the overlay the first window
            QtCore.Qt.FramelessWindowHint |  # remove window border
            QtCore.Qt.X11BypassWindowManagerHint
        )

        screen_geometry = QtWidgets.qApp.desktop().availableGeometry()  # screen resolutions
        self.setGeometry(0, 0, screen_geometry.width(), screen_geometry.height())  # set overlay resolutions

        self.label = QtWidgets.QLabel(self)  # text settings
        self.label.setText('Select an area:')
        self.label.setAlignment(QtCore.Qt.AlignCenter)
        self.label.setGeometry(0, 0, screen_geometry.width() // 2, 50)
        self.label.move(screen_geometry.width() // 4, 0)
        self.label.setStyleSheet('color: rgba(0, 0, 0, 255); background-color: rgba(255, 0, 0, 255); font: 18pt;')

        self.rubberBand = QtWidgets.QRubberBand(QtWidgets.QRubberBand.Rectangle, self)  # used for visual area selection

    def mousePressEvent(self, event):
        self.selected_area.append((event.pos().x(), event.pos().y()))  # get x and y of second position
        self.rubberBand.setGeometry(QtCore.QRect(event.pos(), QtCore.QSize()))  # start the area selection visualisation
        self.rubberBand.show()

    def mouseMoveEvent(self, event):
        # update the selected area visually
        self.rubberBand.setGeometry(QtCore.QRect(QtCore.QPoint(*self.selected_area[0]), event.pos()).normalized())

    def mouseReleaseEvent(self, event):
        self.selected_area.append((event.pos().x(), event.pos().y()))  # get x and y of second position
        QtWidgets.qApp.quit()  # close the overlay


def select_area():
    """
    Selects an area on the screen
    :return the area that the user selected (two points)
    """
    app = QtWidgets.QApplication(sys.argv)
    mywindow = SelectWindow()
    mywindow.show()
    app.exec_()
    return mywindow.selected_area


def copy_video_sound(video_sound_path, video_out_path, video_clip_path):
    """ copies a video's sound onto another video
    :param video_sound_path: the path to the video with soun
    :param video_out_path: the output path to save the new video at
    :param video_clip_path: the path to the video we want to add sound to
    """
    video_out_path = video_out_path.split('.', -1)[0]  # remove the file type from the path
    #load the video
    my_clip = mp.VideoFileClip(video_clip_path)
    #load sound
    audio_background = mp.AudioFileClip(video_sound_path)
    #mix the sound and video
    final_clip = my_clip.set_audio(audio_background)

    #output the video
    final_clip.write_videofile(video_out_path + '.mp4', codec= 'mpeg4' ,audio_codec='libvorbis')


def process_video(video_path, out_path, frame_function):
    """ applies a filter for every frame of a video
    :param video_path: the video we apply a filter to
    :param out_path: the output path we save the processed video at
    :param frame_function: the filter we apply on each frame
    """

    # loading video
    cap = cv2.VideoCapture(video_path)

    #getting width & height of video
    frame_width = int(cap.get(3))
    frame_height = int(cap.get(4))
    fps = int(cap.get(5))

    # creating output video
    fourcc = cv2.VideoWriter_fourcc(*'MJPG')
    out = cv2.VideoWriter(out_path, fourcc, fps, (frame_width,frame_height))
    frame_to_write = 0
    i = fps
    while (True):
        ret, frame = cap.read()

        if not ret:
            break
        if i % fps == 0:
            frame_to_write = frame_function(frame)
            frame_to_write = cv2.resize(frame_to_write, (frame_width,frame_height))


        out.write(frame_to_write)
        i += 1

    cap.release()
    out.release()
    cv2.destroyAllWindows()


