namespace _07.Take_Or_Skip_Rope
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TakeOrSkipRope
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var numbersList = new List<int>();
            numbersList = GetNumbersList(text);
            var textWithoutDigits = GetTextWithoutDigits(text);

            var takeList = GetTakeList(numbersList);
            var skipList = GetSkipList(numbersList);

            var result =  new StringBuilder();
            var skipTotal = 0;

            for (int i = 0; i < skipList.Count; i++)
            {
                result.Append(string.Concat(textWithoutDigits.Skip(skipTotal).Take(takeList[i])));
                skipTotal += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }

        public static List<int> GetNumbersList(string text)
        {
            var numbersList = new List<int>();

            foreach (var letter in text)
            {
                if (char.IsNumber(letter))
                {
                    numbersList.Add(int.Parse(letter.ToString()));
                }
            }

            return numbersList;
        }

        public static string GetTextWithoutDigits(string text)
        {
            var sb = new StringBuilder();

            foreach (var letter in text)
            {
                if (!char.IsNumber(letter))
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }

        public static List<int> GetSkipList (List<int> numbers)
        {
            var skipList = new List<int>();

            for (int i = 1; i < numbers.Count; i+=2)
            {
                skipList.Add(numbers[i]);
            }

            return skipList;
        }

        public static List<int> GetTakeList(List<int> numbers)
        {
            var takeList = new List<int>();

            for (int i = 0; i < numbers.Count; i += 2)
            {
                takeList.Add(numbers[i]);
            }

            return takeList;
        }
    }
}