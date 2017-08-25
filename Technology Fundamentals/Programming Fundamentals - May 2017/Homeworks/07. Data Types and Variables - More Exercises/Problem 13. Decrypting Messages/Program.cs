namespace Problem_13.Decrypting_Messages
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var key = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            var resultString = string.Empty;

            for (int i = 0; i < linesCount; i++)
            {
                var letter = Console.ReadLine().ToCharArray();

                resultString += (char)(letter[0] + key);
            }

            Console.WriteLine(resultString);
        }
    }
}