// See https://aka.ms/new-console-template for more information

using System;
using OpenCvSharp;

class Program
{
    static void Main()
    {
        string videoFile = "video.mp4";
        System.IO.Directory.CreateDirectory("frames");

        using var capture = new VideoCapture(videoFile);
        using var window = new Window("Frame Preview");
        Mat frame = new Mat();

        int frameNumber = 0;
        
    }
}