#include <opencv2/opencv.hpp>
#include <vector>
#include <fstream>
#include <iostream>
#include <filesystem>

using namespace cv;
namespace fs = std::filesystem;


void mergeOverlappingRects(std::vector<Rect>& rects);
void printRectContours(Mat& img, std::vector<Rect> contours);


int main()
{   
    char bla = '!';

    for (int i = 0; i < 94; i++)
    {
        std::cout << bla << "   ";
        bla += 1;
    }
    std::cout << std::endl;

    // get all image of fonts from fonts directory
    std::vector<std::string> fontFiles;
    std::string path = "fonts";
    for (auto& p : fs::directory_iterator(path))
        fontFiles.push_back((p.path().string()));

    for (int i = 0; i < fontFiles.size(); i++)
    {
        Mat font = imread(fontFiles[i]);
        Mat temp = imread(fontFiles[i]);
        std::vector<std::vector<cv::Point>> contours;
        std::vector<Vec4i> hierarchy;
		
		// if cant open image
        if (font.empty())
        {
            std::cout << "Could not read the image: " << "font" + std::to_string(i) + ".jpg" << std::endl;
            return 1;
        }

        imshow(fontFiles[i], font); // show the regolar font
        moveWindow(fontFiles[i], 0, 0);

		
        cv::cvtColor(font, font, cv::COLOR_RGB2GRAY);
        cv::threshold(font, font, 128, 255, THRESH_BINARY);

        findContours(font, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);                  

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

        std::cout << std::to_string(hierarchy.size()) << std::endl;

        std::cout << std::to_string(rectsCharVecotr.size()) << std::endl;

        mergeOverlappingRects(rectsCharVecotr);

        //printRectContours(temp, rectsCharVecotr);


        imshow("Contours", temp);
        moveWindow("Contours", 200, 0);

        // sort all the rect vector from hige left to lower rhigt (by alon sason the king)
        sort(rectsCharVecotr.begin(), rectsCharVecotr.end(), [](Rect a, Rect b) {return (a.y + a.height) < b.y || (a.y < b.y + b.height && a.x < b.x); });

        //show all letter by the sort
        char checkLatter = '!';
        for (int i = 0; i < rectsCharVecotr.size(); i++)
        {
            //if (rectsCharVecotr[i].width > 10)  // if have a point like int char i and j we want to ignore this rigth now
            //{
                temp = font(rectsCharVecotr[i]);  // cut the image were the later
                imshow(std::to_string(i), temp);
                moveWindow(std::to_string(i), 200, 0);           

                std::cout << checkLatter << std::endl;
                checkLatter += 1;

                waitKey();
                cv::destroyWindow(std::to_string(i));
            //}
        }

        waitKey();
        cv::destroyWindow("Input Image");
        cv::destroyWindow("Contours");

        waitKey(0);
    }
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
/*
the function print ract contours in Mat img
----
input: pointer img to draw and vector of all ract to draw
----
output: nane
*/
void printRectContours(Mat& img, std::vector<Rect> contours)
{
    for (size_t i = 0; i < contours.size(); i++) {

        rectangle(img, Point(contours[i].x, contours[i].y), Point(contours[i].x + contours[i].width, contours[i].y + contours[i].height), Scalar(255, 0, 0));
    }
}