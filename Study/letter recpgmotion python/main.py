import numpy as np 
import cv2 

#read the image
img_vanila = cv2.imread("font1.jpg")
img_contours = cv2.imread("font1.jpg")

#find contours and hierachy
imgray = cv2.cvtColor(img_vanila, cv2.COLOR_BGR2GRAY)
ret, thresh = cv2.threshold(imgray, 127,255,0)
contours, hierarchy = cv2.findContours(thresh, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

# find only letter by hiercy
#rect = cv2.cv2.boundingRect(contour) # init varubl
rectsCharVecotr = []
hierarchy = hierarchy[0] # get the actual inner list of hierarchy descriptions


for i in range(len(contours)):

    x,y,w,h = cv2.boundingRect(contours[i])
    
    if hierarchy[i][3] == 0: # 3 is the hirechy index
        rectsCharVecotr.append(contours[i])
        cv2.rectangle(img_contours, (x,y),(x+w,y+h), (255,0,0), 0)  # drow the good hireacrhy in blue
    else:
        cv2.rectangle(img_contours, (x,y),(x+w,y+h), (0,0,255), 2)  # drow the bad hireacrhy in red


#show the image
cv2.imshow("Contours", img_contours)
cv2.waitKey(0) 
cv2.destroyAllWindows() 