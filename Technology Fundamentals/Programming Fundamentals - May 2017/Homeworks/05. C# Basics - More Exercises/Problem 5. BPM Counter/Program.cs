namespace Problem_5.BPM_Counter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var beatsPerMinute = int.Parse(Console.ReadLine());
            var totalBeats = int.Parse(Console.ReadLine());

            var bars = (double)totalBeats / 4;
            var minutes = ((totalBeats / beatsPerMinute) * 60) / 60;
            var seconds = (double)totalBeats / beatsPerMinute * 60; 

            if(minutes > 0)
            {
                seconds -= minutes * 60;
            }

            Console.WriteLine($"{Math.Round(bars,1)} bars - {(int)minutes}m {(int)seconds}s");
        }
    }
}