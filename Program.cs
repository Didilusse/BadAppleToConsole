// See https://aka.ms/new-console-template for more information

using System;
using OpenCvSharp;

class Program
{
    static void Main()
    {
        string videoFile = "/Users/adil/Developer/C#/BadAppleToConsole/BadAppleToConsole/video.mp4";
        System.IO.Directory.CreateDirectory("frames");

        using var capture = new VideoCapture(videoFile);
        using var window = new Window("Frame Preview");
        Mat frame = new Mat();

        int frameNumber = 0;

        while (capture.IsOpened())
        {
            capture.Read(frame);
            if (frame.Empty())
                break;

            frameNumber++;
            Console.WriteLine($"Processing Frame {frameNumber}: {frame.Width}x{frame.Height}");

            // Loop through each pixel
            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Vec3b pixel = frame.At<Vec3b>(y, x); 
                    byte blue = pixel.Item0;
                    byte green = pixel.Item1;
                    byte red = pixel.Item2;

                    Console.WriteLine($"Frame {frameNumber} - Pixel[{x},{y}]: R={red}, G={green}, B={blue}");
                }
            }
            // Show the frame
            window.ShowImage(frame);
            if (Cv2.WaitKey(1) == 113) // Press 'Q' to quit
                break;
        }

        Console.WriteLine("Processing Complete!");
    }
}