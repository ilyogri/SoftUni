namespace _3.Text_filter
{
    using System;

    public class Strings
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            var text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
}