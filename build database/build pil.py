from PIL import Image, ImageFont, ImageDraw
import matplotlib.font_manager
import string
import os




lower_case = dict.fromkeys(string.ascii_lowercase, 0)
upper_case = dict.fromkeys(string.ascii_uppercase, 0)




def create_img_char_midel(color, latter, font_path, checkLowerCase):

    im = Image.new("RGB", (128, 128), color)
    d = ImageDraw.Draw(im)
    location = (40, 0)


    font =  ImageFont.truetype(font_path, size=100)


    if (not os.path.isdir("image_latter_uppercase\\" + latter)):
        os.mkdir("image_latter_uppercase\\" + latter)
    if (color == (255,255,255)):
        latter_color = (0,0,0)
    else:
        latter_color = (255, 255, 255)



    d.text(location, latter, font=font, fill=latter_color)
    if  (checkLowerCase):
        im.save("image_latter_uppercase\\" + latter + "\\" + str(lower_case[latter]) + ".png", "PNG")
        lower_case[latter] += 1
    else:
        im.save("image_latter_uppercase\\" + latter + "\\" + str(upper_case[latter]) + ".png", "PNG")
        upper_case[latter] += 1


fonts_path = matplotlib.font_manager.findSystemFonts(fontpaths="C:\\Users\\WIN10\\Desktop\\build database\\ofl", fontext='ttf')

count = 0
for path in fonts_path:

    #for latter in string.ascii_lowercase: # saving lower latter
     #   create_img_char_midel((0,0,0), latter, path, True)
      #  create_img_char_midel((255,255,255), latter, path, True)


    for latter  in string.ascii_uppercase: # saving uper case latter
        #print(latter)
        create_img_char_midel((0, 0, 0), latter, path, False)
        create_img_char_midel((255, 255, 255), latter, path, False)

    print(count)
    count += 1



