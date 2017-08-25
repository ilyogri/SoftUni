namespace _01.Censorship
{
    using System;

   public class Censorship
    {
        public static void Main()
        {
            var censorWord = Console.ReadLine();
            var text = Console.ReadLine();

            text = text.Replace(censorWord, new string('*', censorWord.Length));
            Console.WriteLine(text);
        }
    }
}