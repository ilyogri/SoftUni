namespace Problem_6.Catch_the_Thief
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numeralType = Console.ReadLine();
            var linesCount = int.Parse(Console.ReadLine());

            long result = long.MinValue;

            for (int i = 0; i < linesCount; i++)
            {
                var inputNumber = long.Parse(Console.ReadLine());

                if (numeralType == "sbyte")
                {
                    if (inputNumber >= sbyte.MinValue && inputNumber <= sbyte.MaxValue && inputNumber > result)
                    {
                        result = inputNumber;
                    }
                }

                else if (numeralType == "int")
                {
                    if (inputNumber >= int.MinValue && inputNumber <= int.MaxValue && inputNumber > result)
                    {
                        result = inputNumber;
                    }
                }

                else if (numeralType == "long")
                {
                    if (inputNumber >= long.MinValue && inputNumber <= long.MaxValue && inputNumber > result)
                    {
                        result = inputNumber;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}