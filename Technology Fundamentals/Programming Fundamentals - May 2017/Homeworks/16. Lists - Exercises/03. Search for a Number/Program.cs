namespace _3.Search_for_a_Number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SearchForANumber
    {
        public static void Main()
        {
            var listOfNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var commandNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var firstNumber = commandNumbers[0];
            var secondNumber = commandNumbers[1];
            var thirdNumber = commandNumbers[2];

            var resultList = new List<int>();

            listOfNumbers = listOfNumbers.Skip(0).Take(firstNumber).ToList();
            listOfNumbers.RemoveRange(0, secondNumber);
            var result = listOfNumbers.Contains(thirdNumber) ? "YES!" : "NO!";

            Console.WriteLine(result);
        }
    }
}