import cv2
import numpy
import ImageProcessing as ip
import moviepy.editor as mp
from PyQt5 import QtWidgets, QtCore, QtGui
from PyQt5.QtCore import QObject, QThread, pyqtSignal
from PIL import ImageGrab
from threading import Thread, Lock
import heapq
import sys


class SelectionWindow(QtWidgets.QMainWindow):

    def __init__(self):
        self.selected_area = []

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
        self.selected_area.append(event.pos().x())  # get x and y of first position
        self.selected_area.append(event.pos().y())
        self.rubberBand.setGeometry(QtCore.QRect(event.pos(), QtCore.QSize()))  # start the area selection visualisation
        self.rubberBand.show()

    def mouseMoveEvent(self, event):
        # update the selected area visually
        first_pos = QtCore.QPoint(self.selected_area[ip.X], self.selected_area[ip.Y])
        self.rubberBand.setGeometry(QtCore.QRect(first_pos, event.pos()).normalized())

    def mouseReleaseEvent(self, event):
        first_pos = QtCore.QPoint(self.selected_area[ip.X], self.selected_area[ip.Y])
        selection_rect = QtCore.QRect(first_pos, event.pos()).normalized()
        self.selected_area = [selection_rect.topLeft().x(), selection_rect.topLeft().y(),
                              selection_rect.bottomRight().x(), selection_rect.bottomRight().y()]
        QtWidgets.qApp.quit()  # close the overlay


class TranslateWorker(QObject):
    word_finished = pyqtSignal(QtGui.QImage, numpy.ndarray)
    frame_finished = pyqtSignal()

    def __init__(self, selected_area, translate_function):
        QObject.__init__(self)
        self.selected_area = selected_area
        self.translate_function = translate_function

    def translate(self):
        while True:
            pil_image = ImageGrab.grab(bbox=self.selected_area)  # grab the area from screen
            frame = cv2.cvtColor(numpy.array(pil_image), cv2.COLOR_RGB2BGR)
            cv2.imshow("frame", frame)
            cv2.waitKey()
            translated_frame, locations = self.translate_function(frame)
            translated_frame = cv2.cvtColor(translated_frame, cv2.COLOR_BGR2RGB)
            self.frame_finished.emit()
            for location in locations:
                (x, y, w, h) = location
                word_img = translated_frame[y:y + h, x:x + w]  # get an image of the translated word
                height, width, _ = word_img.shape
                bytes_per_line = 3 * width
                qt_img = QtGui.QImage(bytes(word_img.data), width, height, bytes_per_line, QtGui.QImage.Format_RGB888)
                self.word_finished.emit(qt_img, location)



class OverlayWindow(QtWidgets.QMainWindow):

    def __init__(self, selected_area, translate_function):
        QtWidgets.QMainWindow.__init__(self)
        self.setAttribute(QtCore.Qt.WA_TranslucentBackground)
        self.setWindowFlags(
           QtCore.Qt.WindowStaysOnTopHint |  # make the overlay the first window
           QtCore.Qt.FramelessWindowHint |  # remove window border
           QtCore.Qt.X11BypassWindowManagerHint
        )
        self.screen_geometry = QtWidgets.qApp.desktop().availableGeometry()  # screen resolutions
        self.setGeometry(0, 0, self.screen_geometry.width(), self.screen_geometry.height())  # set overlay resolutions

        if not selected_area:
            selected_area = [0, 0, self.screen_geometry.width(), self.screen_geometry.height()]
        self.selected_area = selected_area
        self.translate_function = translate_function

        self.images = []

        self.translate_thread = QThread()
        self.translate_worker = TranslateWorker(selected_area, translate_function)
        self.translate_worker.moveToThread(self.translate_thread)
        self.translate_thread.started.connect(self.translate_worker.translate)
        self.translate_worker.word_finished.connect(self.add_image)
        self.translate_worker.frame_finished.connect(self.remove_images)
        self.translate_thread.start()

    def add_image(self, qt_image, location):
        self.images.append(QtWidgets.QLabel(self))
        self.images[-1].setPixmap(QtGui.QPixmap(qt_image))
        self.images[-1].move(self.selected_area[ip.X] + location[ip.X], self.selected_area[ip.Y] + location[ip.Y])
        self.images[-1].show()

    def remove_images(self):
        for image in self.images:
            image.hide()
        self.images = []



def select_area():
    """
    Selects an area on the screen
    :return the area that the user selected (two points)
    """
    app = QtWidgets.QApplication(sys.argv)
    my_window = SelectionWindow()
    my_window.show()
    app.exec_()  # run until the area is selected
    print(my_window.selected_area)
    return my_window.selected_area


def translate_screen(selected_area=[], translate_function=ip.translate_image):
    """
    translates the screen in real time using an overlay
    :param selected_area: the selected area to translate
    :param translate_function: the function used to translate the screen
    """
    app = QtWidgets.QApplication(sys.argv)
    overlay = OverlayWindow(selected_area, translate_function)  # create overlay
    overlay.show()
    app.exec()  # run the gui


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


def process_video(video_path, out_path, filter_function=ip.translate_image):
    """ applies a filter for every frame of a video
    :param video_path: the video we apply a filter to
    :param out_path: the output path we save the processed video at
    :param filter_function: the filter we apply on each frame
    """

    # loading video
    cap = cv2.VideoCapture(video_path)

    #getting width & height of video
    frame_width = int(cap.get(3))
    frame_height = int(cap.get(4))
    fps = int(cap.get(5))

    # creating output video
    fourcc = cv2.VideoWriter_fourcc(*'MJPG')
    out = cv2.VideoWriter(out_path, fourcc, fps, (frame_width, frame_height))
    frame_count = 0
    threads = []
    frames_heap = []
    while True:
        ret, frame = cap.read()

        if not ret:
            break
        if frame_count % fps == 0:  # process with speed of 1 fps
            # process the frame on a different thread
            threads.append(Thread(target=process_frame, args=(filter_function, frames_heap, frame, frame_count)))
            threads[-1].start()  # start the thread
        frame_count += 1

    for i in range(frame_count):
        if i % fps == 0:  # if its a processed frame
            threads.pop(0).join()  # wait for the thread to finish
            _, frame = heapq.heappop(frames_heap)  # get the processed frame
        frame = cv2.resize(frame, (frame_width, frame_height))
        out.write(frame)

    cap.release()
    out.release()
    cv2.destroyAllWindows()


def process_frame(frame_function, frames_heap, frame, index):
    """ processes a frame and enters it to a frame heap with its index
    :param frame_function: the function to process the frame with
    :param frames_heap: a priority queue (heap) we enter the frame into
    :param frame: the frame to process
    :param index: the frame's index
    """
    frame_to_write = frame_function(frame)
    heapq.heappush(frames_heap, (index, frame_to_write))  # add the frame to the frame list



