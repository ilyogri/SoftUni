namespace Problem_8.SMS_Typing
{
    using System;

    public class Program
    {
        public static void Main()
        {

            var linesCount = int.Parse(Console.ReadLine());

            var message = string.Empty;

            for (int i = 0; i < linesCount; i++)
            {
                var currentLetter = Console.ReadLine().ToCharArray();
                var currentLetterLength = currentLetter.Length;

                switch (currentLetter[0])
                {
                    case '2':
                        message += ((char)('a' + currentLetterLength - 1)).ToString();
                        break;
                    case '3':
                        message += ((char)('d' + currentLetterLength - 1)).ToString();
                        break;
                    case '4':
                        message += ((char)('g' + currentLetterLength - 1)).ToString();
                        break;
                    case '5':
                        message += ((char)('j' + currentLetterLength - 1)).ToString();
                        break;
                    case '6':
                        message += ((char)('m' + currentLetterLength - 1)).ToString();
                        break;
                    case '7':
                        message += ((char)('p' + currentLetterLength - 1)).ToString();
                        break;
                    case '8':
                        message += ((char)('t' + currentLetterLength - 1)).ToString();
                        break;
                    case '9':
                        message += ((char)('w' + currentLetterLength - 1)).ToString();
                        break;
                    default:
                        message += " ";
                        break;
                }
            }

            Console.WriteLine(message);         
        }
    }
}