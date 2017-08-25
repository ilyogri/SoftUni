namespace Problem_1.X
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var linesCount =  int.Parse(Console.ReadLine());

            var leftSpaces = 0;
            var middleSpaces = linesCount - 2;

            for (int i = 1; i <= linesCount / 2; i++)
            {
                Console.WriteLine(new string(' ',leftSpaces) + 'x' + new string(' ', middleSpaces) + 'x');

                leftSpaces++;
                middleSpaces-=2;
            }

            Console.WriteLine(new string(' ', leftSpaces) + 'x');

            middleSpaces = 1;
            leftSpaces--;

            for (int i = 1; i <= linesCount / 2; i++)
            {
                Console.WriteLine(new string(' ', leftSpaces) + 'x' + new string(' ', middleSpaces) + 'x');

                leftSpaces--;
                middleSpaces += 2;
            }
        }
    }
}