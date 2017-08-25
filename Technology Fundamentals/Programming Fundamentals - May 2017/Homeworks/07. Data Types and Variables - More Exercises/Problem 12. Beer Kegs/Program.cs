namespace Problem_12.Beer_Kegs
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var bestModel = string.Empty;
            var bestResult = 0.0;

            for (int i = 0; i < linesCount; i++)
            {
                var model = Console.ReadLine();
                var radius = double.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());

                var volumeAlgorithm = Math.PI * radius * radius * height;

                if(volumeAlgorithm > bestResult)
                {
                    bestModel = model;
                    bestResult = volumeAlgorithm;
                }
            }

            Console.WriteLine(bestModel);
        }
    }
}