namespace _3.English_Name_оf_The_Last_Digit
{
    using System;
    using System.Linq;

   public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetEnglishNameOfLastDigit(number));
        }

        public static string GetEnglishNameOfLastDigit(int number)
        {
            var lastDigit = number.ToString().Last().ToString();

            switch (lastDigit)
            {
                case "1":
                    return "one";
                case "2":
                    return "two";
                case "3":
                    return "three";
                case "4":
                    return "four";
                case "5":
                    return "five";
                case "6":
                    return "six";
                case "7":
                    return "seven";
                case "8":
                    return "eight";
                case "9":
                    return "nine";
            }

            return "zero";
        }
    }
}