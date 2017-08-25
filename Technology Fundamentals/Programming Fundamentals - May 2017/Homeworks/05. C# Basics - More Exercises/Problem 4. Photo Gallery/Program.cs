namespace Problem_4.Photo_Gallery
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var photoNumber = int.Parse(Console.ReadLine());
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var sizeImage = double.Parse(Console.ReadLine());
            var widthImage = int.Parse(Console.ReadLine());
            var heightImage = int.Parse(Console.ReadLine());

            var orientation = string.Empty;
            orientation = GetOrientation(widthImage, heightImage, orientation);

            var sizeType = GetSizeType(sizeImage);
            sizeImage = GetSizeValue(sizeImage);

            Console.WriteLine($"Name: DSC_{photoNumber.ToString("#0000")}.jpg");
            Console.WriteLine($"Date Taken: {day.ToString("#00")}/{month.ToString("#00")}/{year} {hours.ToString("#00")}:{minutes.ToString("#00")}");
            Console.WriteLine($"Size: {sizeImage}{sizeType}");
            Console.WriteLine($"Resolution: {widthImage}x{heightImage} ({orientation})");
        }

        public static string GetOrientation(int widthImage, int heightImage, string orientation)
        {
            if (widthImage > heightImage)
            {
                return orientation = "landscape";
            }

            else if (widthImage < heightImage)
            {
                return orientation = "portrait";
            }

            else
            {
                return orientation = "square";
            }
        }

        public static double GetSizeValue (double sizeImage)
        {
            var sizeLength = sizeImage.ToString().ToArray().Length;

            var convertedSizeImage = 0.0;

            if (sizeLength <= 6 && sizeLength > 3)
            {
                sizeImage*= 0.001;
            }

            else if(sizeLength > 6)
            {
                sizeImage *= 0.000001;
            }

            return sizeImage;
        }

        public static string GetSizeType(double sizeImage)
        {
            var sizeType = string.Empty;
            var sizeImageArray = sizeImage.ToString().ToArray();
            var sizeLength = sizeImageArray.Length;

            if (sizeLength <= 6 && sizeLength > 3)
            {
                sizeType = "KB";
            }

            else if (sizeLength > 6)
            {
                sizeType = "MB";
            }

            else
            {
                sizeType = "B";
            }

            return sizeType;
        }
    }
}