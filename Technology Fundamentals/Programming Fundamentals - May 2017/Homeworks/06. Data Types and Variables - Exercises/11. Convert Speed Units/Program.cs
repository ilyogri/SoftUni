namespace _11.Convert_Speed_Units
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var distance = int.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var seconds = int.Parse(Console.ReadLine());

            float timeSec = (hours * 3600) + (minutes * 60) + seconds;
            float mps = distance / timeSec;
            float kph = ((distance / 1000.0f) / (timeSec / 3600.0f));
            float mph = kph / 1.609f;

            Console.WriteLine(mps);
            Console.WriteLine(kph);
            Console.WriteLine(mph);
        }
    }
}