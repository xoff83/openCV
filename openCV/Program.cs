using OpenCvSharp;
using System;

namespace openCV
{

    internal class Program
    {
        static void LoadAndDisplayImage()
        {
            string imagePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\images\\logo.jpg";
            Mat colorImage = Cv2.ImRead(imagePath, ImreadModes.Color);
            Mat blackNwhiteImage = Cv2.ImRead(imagePath, ImreadModes.Grayscale);
            Cv2.ImShow("Color Image", colorImage);
            Cv2.ImShow("BW Image", blackNwhiteImage);
            Cv2.WaitKey(0);
        }


        static void Main(string[] args)
        {

            CameraModule faceFeatureDetection = new CameraModule();
            faceFeatureDetection.Init();
            faceFeatureDetection.DetectFeatures();
            faceFeatureDetection.Release();

            FrameModule cameraModule = new FrameModule();
            try
            {
                cameraModule.Init();
                var capturedImage = cameraModule.Capture(save: true);
                var manipulatedImage = cameraModule.Manipulate(capturedImage);
                cameraModule.ShowImage(capturedImage);
                cameraModule.ShowImage(manipulatedImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops something happened! {0}", ex.Message);
            }
            finally
            {
                cameraModule.Release();
            }

            LoadAndDisplayImage();


        }
    }
}
