import cv2
import moviepy.editor as mp


def copy_video_sound(video_sound_path, video_out_path, video_clip_path):
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

    # loading video
    cap = cv2.VideoCapture(video_path)
    # creating output video
    fourcc = cv2.VideoWriter_fourcc(*'MJPG')
    out = cv2.VideoWriter(out_path, fourcc, 20.0, (640, 480), False)

    while (True):
        ret, frame = cap.read()
        if not ret:
            break

        frame = frame_function(frame)
        out.write(frame)

    cap.release()
    out.release()

