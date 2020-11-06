#include <opencv2/opencv.hpp>
#include <iostream>
#include <vector>

using namespace cv;

int main()
{
	Mat font = imread("font1.jpg");
	Mat temp = imread("font1.jpg");
    std::vector<std::vector<cv::Point>>contours;
    std::vector<Vec4i> hierarchy;

    

    if (font.empty())
    {
        std::cout << "Could not read the image: " << "font1.jpg" << std::endl;
        return 1;
    }

    cv::cvtColor(font, font, cv::COLOR_RGB2GRAY);
    cv::threshold(font, font, 128, 255, THRESH_BINARY);

    
    findContours(font, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);

    for (int i = 0; i < hierarchy.size(); i++)
    {
        std::cout << hierarchy[i] << std::endl;
    }

    //Draw the contours
    cv::Mat contourImage(font.size(), CV_8UC3, cv::Scalar(0, 0, 0));
    cv::Scalar colors[3];
    colors[0] = cv::Scalar(255, 0, 0);
    colors[1] = cv::Scalar(0, 255, 0);
    colors[2] = cv::Scalar(0, 0, 255);

    Rect rect;

    for (size_t idx = 0; idx < contours.size(); idx++) {
        rect = boundingRect(contours[idx]);
        if (hierarchy[idx][3] == 0)        
            rectangle(contourImage, Point(rect.x, rect.y), Point(rect.x + rect.width, rect.y + rect.height), Scalar(255, 0, 0));
        
        else       
            rectangle(contourImage, Point(rect.x, rect.y), Point(rect.x + rect.width, rect.y + rect.height), colors[2]);
        
    }

    imshow("Input Image", font);
    moveWindow("Input Image", 0, 0);
    cv::imshow("Contours", contourImage);
    moveWindow("Contours", 200, 0);
    imshow("basic", temp);

    waitKey(0);

	return 0;
}