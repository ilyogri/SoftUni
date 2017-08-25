namespace _19.Thea_the_Photographer
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int totalPictures = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            double filteredPictures = Math.Ceiling(totalPictures * (filterFactor * 0.01));
            double firstTime = totalPictures * (long)filterTime;
            double secondTime = filteredPictures * (long)uploadTime;
            double totalTime = firstTime + secondTime;

            double seconds = (int)(totalTime % 60);
            double minutes = (int)((totalTime / 60) % 60);
            double hours = (int)(((totalTime / 60) / 60) % 24);
            double days = (int)(((totalTime / 60) / 60) / 24);

            Console.WriteLine("{0}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);
        }
    }
}