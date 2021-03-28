import cv2
import numpy
import ImageProcessing as ip
import moviepy.editor as mp
from PyQt5 import QtWidgets, QtCore, QtGui
from PyQt5.QtCore import QObject, QThread, pyqtSignal, QEventLoop
from PIL import ImageGrab, ImageTk, Image
from threading import Thread, Lock, Condition
import heapq
import sys
import tkinter as tk

image_lock = Lock()


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

    add_images = pyqtSignal(list, list)  # signals to call functions from gui thread
    remove_images = pyqtSignal()

    def __init__(self, selected_area, translate_function):
        QObject.__init__(self)
        self.selected_area = selected_area
        self.translate_function = translate_function
        self.loop = QEventLoop(self)  # an event loop that waits for images on overlay to be removed

    def translate(self):
        """
        translates the screen
        """
        locations = []
        qt_images = []
        while True:
            self.remove_images.emit()  # remove the previous images before grabbing from screen
            self.loop.exec()  # wait until the images are removed
            pil_image = ImageGrab.grab(bbox=self.selected_area)  # grab the area from screen
            self.add_images.emit(qt_images, locations)
            qt_images = []  # reset the images list
            frame = cv2.cvtColor(numpy.array(pil_image), cv2.COLOR_RGB2BGR)  # convert the frame to a cv2 image
            translated_frame, locations = self.translate_function(frame)  # translate the frame
            translated_frame = cv2.cvtColor(translated_frame, cv2.COLOR_BGR2RGB)

            for location in locations:  # for each translated word
                (x, y, w, h) = location
                word_img = translated_frame[y:y + h, x:x + w]  # get an image of the translated word
                height, width, _ = word_img.shape  # convert the image to a qt image
                bytes_per_line = 3 * width
                qt_img = QtGui.QImage(bytes(word_img.data), width, height, bytes_per_line, QtGui.QImage.Format_RGB888)
                qt_images.append(qt_img)


class OverlayWindow(QtWidgets.QMainWindow):

    removed_images = pyqtSignal()  # a signal that notifies when all the images on overlay were removed

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

        if not selected_area:  # if no area was selected
            # set selected area to screen resolutions
            selected_area = [0, 0, self.screen_geometry.width(), self.screen_geometry.height()]
        self.selected_area = selected_area
        self.translate_function = translate_function

        self.images = []

        self.translate_thread = QThread()  # create a different thread to handle the screen translation
        self.translate_worker = TranslateWorker(selected_area, translate_function)
        self.translate_worker.moveToThread(self.translate_thread)  # connect the worker to the thread
        self.translate_thread.started.connect(self.translate_worker.translate)  # connect all the signals
        self.translate_worker.add_images.connect(self.add_images)
        self.translate_worker.remove_images.connect(self.remove_images)
        self.removed_images.connect(self.translate_worker.loop.quit)
        self.translate_thread.start()

    def add_images(self, qt_images, locations):
        image_lock.acquire()
        for i in range(len(qt_images)):  # add each image
            self.add_image(qt_images[i], locations[i])
        image_lock.release()

    def add_image(self, qt_image, location):
        """
        adds an image to the overlay
        :param qt_image: the image to add
        :param location: the location to add it at
        """
        self.images.append(QtWidgets.QLabel(self))  # add an image to the list
        self.images[-1].setPixmap(QtGui.QPixmap(qt_image))  # set the image to the given image
        self.images[-1].move(self.selected_area[ip.X] + location[ip.X], self.selected_area[ip.Y] + location[ip.Y])
        self.images[-1].show()

    def remove_images(self):
        """
        removes all the images on screen
        """
        image_lock.acquire()  # lock when using the image list
        for image in self.images:  # hide all the images
            image.hide()
        self.images = []  # empty the images list
        image_lock.release()
        self.removed_images.emit()  # notify the worker thread that all images were removed


def select_area():
    """
    Selects an area on the screen
    :return the area that the user selected (two points)
    """
    app = QtWidgets.QApplication(sys.argv)
    my_window = SelectionWindow()
    my_window.show()
    app.exec()  # run until the area is selected
    return my_window.selected_area


#def translate_screen(selected_area=[], translate_function=ip.translate_image):
    """
    translates the screen in real time using an overlay
    :param selected_area: the selected area to translate
    :param translate_function: the function used to translate the screen
    """
    #app = QtWidgets.QApplication(sys.argv)
    #overlay = OverlayWindow(selected_area, translate_function)  # create overlay
    #overlay.show()
    #app.exec()  # run the gui


class Overlay:
    def __init__(self, master, selected_area, condition_variable):
        self.master = master
        master.attributes('-fullscreen', True)  # make the overlay fullscreen
        master.attributes('-transparentcolor', master['bg'])  # make the overlay transparent
        master.attributes('-topmost', True)  # make the overlay always stay on top

        # create a canvas on the entire screen
        self.canvas = tk.Canvas(master, width=master.winfo_screenwidth(), height=master.winfo_screenheight())
        self.canvas.pack()

        if not selected_area:  # if no area was selected
            # set selected area to screen resolutions
            selected_area = [0, 0, master.winfo_screenwidth(), master.winfo_screenwidth()]
        self.selected_area = selected_area

        self.cv = condition_variable
        self.images = []

    def translate(self, translate_function):
        """
        translates the screen infinitely
        :param translate_function: the function used to translate each frame
        """
        locations = []
        pil_images = []
        while True:
            with self.cv:  # lock before removing images to not miss the signal
                self.master.after(0, self.remove_images)  # remove the previous images before grabbing from screen
                self.cv.wait()  # wait until the images are removed
            pil_image = ImageGrab.grab(bbox=self.selected_area)  # grab the area from screen
            self.master.after(0, self.add_images(pil_images, locations))
            pil_images = []  # reset the images list
            frame = cv2.cvtColor(numpy.array(pil_image), cv2.COLOR_RGB2BGR)  # convert the frame to a cv2 image
            translated_frame, locations = translate_function(frame)  # translate the frame
            translated_frame = cv2.cvtColor(translated_frame, cv2.COLOR_BGR2RGB)

            for location in locations:  # for each translated word
                (x, y, w, h) = location
                word_img = translated_frame[y:y + h, x:x + w]  # get an image of the translated word
                word_img = Image.fromarray(word_img)  # convert the frame to a pil image
                pil_images.append(word_img)  # add the image

    def add_images(self, pil_images, locations):
        """
        adds images to the overlay
        :param pil_images: the pillow images to add
        :param locations: the locations to add them at
        """
        for i in range(len(pil_images)):  # add each image
            self.add_image(pil_images[i], locations[i])

    def add_image(self, pil_image, location):
        """
        adds an image to the overlay
        :param pil_image: the pillow image to add
        :param location: the location to add it at
        """
        print("adding")
        self.images.append(ImageTk.PhotoImage(pil_image))  # save the image so it doesnt get garbage collected
        # add the image to the canvas
        self.canvas.create_image(self.selected_area[ip.X] + location[ip.X], self.selected_area[ip.Y] + location[ip.Y],
                                 anchor=tk.NW, image=self.images[-1])

    def remove_images(self):
        """
        removes all the images on screen
        """
        self.canvas.delete("all")  # clear the canvas
        self.images = []  # empty all the images
        with self.cv:
            self.cv.notify()


def translate_screen(selected_area=[], translate_function=ip.translate_image):
    """
    translates the screen in real time using an overlay
    :param selected_area: the selected area to translate
    :param translate_function: the function used to translate the screen
    """

    root = tk.Tk()
    overlay = Overlay(root, selected_area, Condition())  # create the overlay
    # create a worker thread for translating the screen
    translate_thread = Thread(target=overlay.translate, args=(translate_function,))
    translate_thread.setDaemon(True)
    translate_thread.start()  # start the thread
    root.mainloop()  # start the event loop


def copy_video_sound(video_sound_path, video_clip_path, video_out_path):
    """ copies a video's sound onto another video
    :param video_sound_path: the path to the video with sound
    :param video_out_path: the output path to save the new video at
    :param video_clip_path: the path to the video we want to add sound to
    """
    # load the video
    my_clip = mp.VideoFileClip(video_clip_path)
    #load sound
    audio_background = mp.AudioFileClip(video_sound_path)
    #mix the sound and video
    final_clip = my_clip.set_audio(audio_background)
    #output the video
    final_clip.write_videofile(video_out_path)


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
    fourcc = cv2.VideoWriter_fourcc(*'MP4V')
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
            print(frame_count)
        else:  # if the frame shouldn't be processed
            heapq.heappush(frames_heap, (frame_count, frame, []))  # add the frame to the frame list
        frame_count += 1

    frame = None
    processed_frame = None
    locations = []
    for i in range(frame_count):
        if i % fps == 0:  # if its a processed frame
            threads.pop(0).join()  # wait for the thread to finish
            _, processed_frame, locations = heapq.heappop(frames_heap)  # get the processed frame
            frame = processed_frame
        else:  # if its a normal frame
            _, frame, _ = heapq.heappop(frames_heap)  # get the frame
            for location in locations:  # copy all the changed locations from the last processed frame to this frame
                (x, y, width, height) = location
                frame[y:y + height, x:x + width] = processed_frame[y:y + height, x:x + width]

        frame = cv2.resize(frame, (frame_width, frame_height))  # resize the frame to the video size
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
    frame_to_write, locations = frame_function(frame)
    heapq.heappush(frames_heap, (index, frame_to_write, locations))  # add the frame to the frame list



