namespace _2.Count_substring_occurrences
{
    using System;

    public class Strings
    {
        public static void Main()
        {
            var inputText = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();

            var matchCounter = 0;
            var index = 0;

            while (true)
            {
                var found = inputText.IndexOf(pattern, index);

                index = found + 1;

                if (found >= 0)
                {
                    matchCounter++;
                }

                else
                {
                    break;
                }
            }

            Console.WriteLine(matchCounter);
        }
    }
}