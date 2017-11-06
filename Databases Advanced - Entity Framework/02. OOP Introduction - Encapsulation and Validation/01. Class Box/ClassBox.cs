namespace _01.Class_Box
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ClassBox
    {
        public static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            
            var box = new Box(length, width, height);
            var surfaceArea = box.CalculateSurfaceArea();
            var lateralSurfaceArea = box.CalculateLateralSurfaceArea();
            var volume = box.CalculateVolume();

            PrintResult(surfaceArea, lateralSurfaceArea, volume);
        }

        public static void PrintResult(double surfaceArea, double lateralSurfaceArea, double volume)
        {
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {volume:f2}");
        }
    }
}