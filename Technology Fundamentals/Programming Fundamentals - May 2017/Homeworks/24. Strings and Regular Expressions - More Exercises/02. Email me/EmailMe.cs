namespace _02.Email_me
{
    using System;
    using System.Linq;

    public class EmailMe
    {
        public static void Main()
        {
            var email = Console.ReadLine();

            var charsLeft = string.Concat(email.TakeWhile(x => x != '@'));
            var charsRight = string.Concat(email.Reverse().TakeWhile(x => x != '@'));

            var charsLeftSum = SumChars(charsLeft);
            var charsRightSum = SumChars(charsRight);

            if(charsLeftSum - charsRightSum >= 0)
            {
                Console.WriteLine("Call her!");
            }

            else
            {
                Console.WriteLine("She is not the one.");
            }
        }

        public static int SumChars(string text)
        {
            var sum = 0;
            foreach (var letter in text)
            {
                sum += letter;
            }

            return sum;
        }
    }
}