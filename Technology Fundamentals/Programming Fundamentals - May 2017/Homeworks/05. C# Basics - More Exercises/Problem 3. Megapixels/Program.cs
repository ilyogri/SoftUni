namespace Problem_3.Megapixels
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var widthPhoto = int.Parse(Console.ReadLine());
            var heightPhoto = int.Parse(Console.ReadLine());

            var pixels = (long)(widthPhoto * heightPhoto);
            var megapixels = (double)pixels / 1000000;

            Console.WriteLine($"{widthPhoto}x{heightPhoto} => {Math.Round(megapixels,1)}MP");
        }
    }
}