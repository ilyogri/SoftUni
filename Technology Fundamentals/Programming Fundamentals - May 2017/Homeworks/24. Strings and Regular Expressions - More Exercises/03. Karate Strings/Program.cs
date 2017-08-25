namespace _03.Karate_Strings
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var strength = 0;
            var charsToRemove = 0;

            foreach (var digit in text.Where(x => char.IsDigit(x)))
            {
                var number = int.Parse(digit.ToString());

                strength += number;
                charsToRemove = strength;

                var index = text.IndexOf(number.ToString());

                while (charsToRemove != 0 && index >= 0)
                {
                    if(text[index] != '>')
                    {
                        text = text.Remove(index, 1);
                        strength--;
                        charsToRemove--;
                    }

                    else
                    {
                        break;
                    }

                    if(index == text.Length)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}