#include <opencv2/opencv.hpp>
#include <iostream>
#include <vector>

using namespace cv;

bool compareContourAreas(std::vector<cv::Point> contour1, std::vector<cv::Point> contour2) {  
    double i = fabs(contourArea(cv::Mat(contour1)));
    double j = fabs(contourArea(cv::Mat(contour2)));
    return (i < j);
}

void mergeOverlappingRects(std::vector<Rect>& rects);

/*
the function print ract contours in Mat img
----
input: pointer img to draw and vector of all ract to draw
----
output: nane
*/
void printRectContours(Mat &img, std::vector<Rect> contours)
{
    for (size_t i = 0; i < contours.size(); i++) {
        
         rectangle(img, Point(contours[i].x, contours[i].y), Point(contours[i].x + contours[i].width, contours[i].y + contours[i].height), Scalar(255, 0, 0));
    }
}

int main()
{
    Mat font = imread("font1.jpg");
    Mat temp = imread("font1.jpg");
    std::vector<std::vector<cv::Point>> contours;
    std::vector<Vec4i> hierarchy;


    if (font.empty())
    {
        std::cout << "Could not read the image: " << "font2.jpg" << std::endl;
        return 1;
    }

    imshow("Input Image", font); // show the regolar font
    moveWindow("Input Image", 0, 0);


    cv::cvtColor(font, font, cv::COLOR_RGB2GRAY);
    cv::threshold(font, font, 128, 255, THRESH_BINARY);

    findContours(font, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);

    for (int i = 0; i < hierarchy.size(); i++)
    {
        std::cout << hierarchy[i] << std::endl;
    }



    Rect rect;
    std::vector<Rect> rectsCharVecotr;

    for (size_t i = 0; i < contours.size(); i++)  // check wiche countor we need
    { 
        rect = boundingRect(contours[i]);  // make shape to rect
        if (hierarchy[i][3] != -1)  // check if it not a insaide rect
        {
            rectsCharVecotr.push_back(rect);
        }
        else
        {
            rectangle(temp, Point(rect.x, rect.y), Point(rect.x + rect.width, rect.y + rect.height), Scalar(0, 0, 255));
        }
    }

    

    mergeOverlappingRects(rectsCharVecotr);

    printRectContours(temp, rectsCharVecotr);


    imshow("Contours", temp);
    moveWindow("Contours", 200, 0);

    // sort all the rect vector from hige left to lower rhigt (by alon sason the king)
    sort(rectsCharVecotr.begin(), rectsCharVecotr.end(), [](Rect a, Rect b) {return (a.y + a.height) < b.y || (a.y < b.y + b.height && a.x < b.x); });

    //show all letter by the sort
    for (int i = 0; i < rectsCharVecotr.size(); i++)
    {
        if (rectsCharVecotr[i].width > 10)  // if have a point like int char i and j we want to ignore this rigth now
        {
            temp = font(rectsCharVecotr[i]);  // cut the image were the later
            imshow(std::to_string(i), temp);
            moveWindow(std::to_string(i), 200, 0);
            waitKey();
        }   
    }

    waitKey(0);

	return 0;
}

void mergeOverlappingRects(std::vector<Rect>& rects)
{
    int i = 0;
    int j = 0;
    int k = 0;
    auto it = rects.begin();
    

    while (i < (rects.size() - 1) && rects.size())
    {
        j = i + 1;
        while (j < rects.size())
        {
            if ((rects[i] & rects[j]).area() > 0) // if the two rectangles overlap 
            {
                rects[i] = rects[i] | rects[j]; // merge them
                it = rects.begin();
                for (k = 0; k < j; k++)
                    it++;
                rects.erase(it); // remove the other rect from the vector since we merged it
                j--; // stay on the same rect to see if it needs more merging
            }
            j++;
        }
        i++;
    }
}
