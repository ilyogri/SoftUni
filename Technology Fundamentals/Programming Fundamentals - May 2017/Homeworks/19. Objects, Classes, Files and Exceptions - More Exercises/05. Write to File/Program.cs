namespace _05.Write_to_File
{
    using System;
    using System.IO;

    public class WriteToFile
    {
        public static void Main()
        {
            var text = File.ReadAllText(@"c:\\sample_text.txt");

            var result = text.Split('.', ',', '!', '?', ':');

            Console.WriteLine(string.Join("", result));
        }
    }
}