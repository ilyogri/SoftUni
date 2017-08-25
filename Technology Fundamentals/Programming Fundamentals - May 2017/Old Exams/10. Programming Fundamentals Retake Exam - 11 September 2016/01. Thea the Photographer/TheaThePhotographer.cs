namespace _01.Thea_the_Photographer
{
    using System;

    public class TheaThePhotographer
    {
        public static void Main()
        {
            var totalPictures = double.Parse(Console.ReadLine());
            var filterTime = double.Parse(Console.ReadLine());
            var filterFactor = double.Parse(Console.ReadLine());
            var uploadTime = double.Parse(Console.ReadLine());

            var filteredPictures = Math.Ceiling(totalPictures * (filterFactor / 100));
            var takenPicturesTime = totalPictures * filterTime;
            var uploadPicturesTime = filteredPictures * uploadTime;

            TimeSpan t = TimeSpan.FromSeconds(takenPicturesTime + uploadPicturesTime);

            string answer = string.Format("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                            t.Days,
                            t.Hours,
                            t.Minutes,
                            t.Seconds);

            Console.WriteLine(answer);
        }
    }
}