namespace _02.Array_Modifier
{
    using System;
    using System.Linq;

   public class ArrayModifier
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
               .Split()
               .Select(long.Parse)
               .ToArray();

            var commandInput = Console.ReadLine();
            while (commandInput != "end")
            {
                var tokens = commandInput.Split();

                var command = tokens[0];
                switch (command)
                {
                    case "swap":
                        var firstIndex = int.Parse(tokens[1]);
                        var secondIndex = int.Parse(tokens[2]);
                        SwapIntegers(numbers, firstIndex, secondIndex);
                        break;
                    case "multiply":
                         firstIndex = int.Parse(tokens[1]);
                         secondIndex = int.Parse(tokens[2]);
                        MultiplyIntegers(numbers, firstIndex, secondIndex);
                        break;
                    case "decrease":
                        numbers = DecreaseIntegers(numbers);
                        break;
                }

                commandInput = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static long[] DecreaseIntegers(long[] numbers)
        {
            return numbers.Select(x => x = --x).ToArray();
        }

        public static void MultiplyIntegers(long[] numbers, int firstIndex, int secondIndex)
        {
            numbers[firstIndex] = numbers[firstIndex] * numbers[secondIndex];
        }

        public static void SwapIntegers(long[] numbers, int firstIndex, int secondIndex)
        {
            var firstNumber = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = firstNumber;
        }
    }
}