#include <opencv2/imgproc.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <iostream>
#include <cmath>

using namespace cv;
using namespace std;

void mergeOverlappingRects(vector<Rect>& rects);
void mergeCloseRects(vector<Rect>& rects);

int main(int argc, char** argv)
{
    unsigned int i = 0;
    unsigned int j = 0;
    double minVal, maxVal;
    vector<vector<Point>> contours;
    vector<Vec4i> hierarchy;
    vector<Rect> rects;
    Rect rect;
    Mat rectKernel = getStructuringElement(MORPH_RECT, Size(17, 5));
    Mat sqKernel = getStructuringElement(MORPH_RECT, Size(5, 5));
    Mat image;
    Mat grayscaleImg;
    Mat topHat;
    Mat threshImg;

    namedWindow("Display window", WINDOW_AUTOSIZE);// Create a window for display.
    namedWindow("thresh1 window", WINDOW_AUTOSIZE);// Create a window for display.
    for (i = 1; i <= 13; i++)
    {
        rects.clear();
        image = imread("pics\\" + std::to_string(i) + ".jpg", CV_LOAD_IMAGE_COLOR);   // Read the file

        if (!image.data)                              // Check for invalid input
        {
            cout << "Could not open or find the image" << std::endl;
            break;
        }
        double imageRatio = ((double)image.rows / image.cols);
        resize(image, image, Size(600, (int)(600 * imageRatio))); // resize image while maintaining the original ratio

        cvtColor(image, grayscaleImg, CV_BGR2GRAY);
        Sobel(grayscaleImg, threshImg, CV_32F, 1, 0, -1);
        abs(threshImg);
        minMaxLoc(threshImg, &minVal, &maxVal); //find minimum and maximum intensities
        threshImg.convertTo(threshImg, CV_8U, 255.0 / (maxVal - minVal), -minVal * 255.0 / (maxVal - minVal)); // min-max normalization
        morphologyEx(threshImg, threshImg, MORPH_CLOSE, rectKernel);
        morphologyEx(threshImg, threshImg, MORPH_CLOSE, rectKernel);
        //adaptiveThreshold(threshImg, threshImg, 255, ADAPTIVE_THRESH_GAUSSIAN_C, THRESH_BINARY, blockSize, c);
        threshold(threshImg, threshImg, 0, 255, THRESH_BINARY | THRESH_OTSU);
        morphologyEx(threshImg, threshImg, MORPH_CLOSE, rectKernel);
        findContours(threshImg, contours, hierarchy, RETR_EXTERNAL, CHAIN_APPROX_SIMPLE);
        for (j = 0; j < contours.size(); j++)
        {
            rect = boundingRect(contours[j]);
            rect = Rect(rect.x - 5, rect.y - 5, rect.width + 5, rect.height + 5);
            rects.push_back(rect);
        }
        for (int k = 0; k < rects.size(); k++)
            cout << "x: " << rects[k].x << " y: " << rects[k].y << endl;
        mergeOverlappingRects(rects); // get rid of overlapping rects
        //sort the rectangles from left to right, top to buttom
        std::sort(rects.begin(), rects.end(), [](Rect a, Rect b) {return a.y + a.height < b.y || (a.y < b.y + b.height && a.x < b.x); });
        cout << "sorted:\n";
        for (int k = 0; k < rects.size(); k++)
            cout << "x: " << rects[k].x << " y: " << rects[k].y << " height: " << rects[k].height << " width: " << rects[k].width << endl;
        mergeCloseRects(rects);
        for (j = 0; j < rects.size(); j++)
            rectangle(image, rects[j], Scalar(255, 0, 0));

        imshow("Display window", image);                   // Show our image inside it.
        imshow("thresh1 window", threshImg);                   // Show our image inside it. 
        waitKey(0);                                          // Wait for a keystroke in the window
    }
    
    return 0;
}

// merges overlapping rects together in a rect vector
void mergeOverlappingRects(vector<Rect>& rects)
{
    unsigned int i = 0;
    unsigned int j = 0;
    unsigned int k = 0;
    auto it = rects.begin();

    while (i < rects.size() - 1)
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

// merges close rects together in a sorted rect vector
void mergeCloseRects(vector<Rect>& rects)
{
    unsigned int i = 0;
    unsigned int j = 0;
    auto it = rects.begin();

    while (i < rects.size() - 1)
    {   
        if (rects[i].y + rects[i].height > rects[i+1].y && rects[i].x + rects[i].width + 5 > rects[i + 1].x) // if the two rectangles are in the same "line" and are close enough 
        {
            rects[i] = rects[i] | rects[i + 1]; // merge them
            it = rects.begin();
            for (j = 0; j < i+1; j++)
                it++;
            rects.erase(it); // remove the next rect from the vector since we merged it
            i--; // stay on the same rect to see if it needs more merging
        }
        i++;
    }
}