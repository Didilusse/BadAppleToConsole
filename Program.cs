// See https://aka.ms/new-console-template for more information

using System;
using System.Text;
using OpenCvSharp;

class Program
{
    static void Main()
    {

        string videoFile = "/Users/adil/Developer/C#/BadAppleToConsole/BadAppleToConsole/video_smaller.mp4";
        

        using var capture = new VideoCapture(videoFile);
        Mat frame = new Mat();
        int frameNumber = 0;
        
        while (capture.IsOpened())
        {
            capture.Read(frame);
            if (frame.Empty())
                break;
            
            
            
            StringBuilder frameOutput = new StringBuilder();
            frameNumber++;
            
            

            // Loop through each pixel
            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Vec3b pixel = frame.At<Vec3b>(y, x); 
                    byte blue = pixel.Item0;
                    byte green = pixel.Item1;
                    byte red = pixel.Item2;
                    if (red == 255 || green == 255 || blue == 255)
                    {
                        frameOutput.Append(" ");
                    }
                    else if (red == 0 && green == 0 && blue == 0)
                    {
                        frameOutput.Append("@");
                    }
                }
                frameOutput.Append('\n');
            }
            Console.Write(frameOutput.ToString());
            
            // Frame rate control
            int delay = (int)(1000 / (capture.Fps > 0 ? capture.Fps : 30));
            Cv2.WaitKey(delay);
        }

        Console.WriteLine("Processing Complete!");
    }
}