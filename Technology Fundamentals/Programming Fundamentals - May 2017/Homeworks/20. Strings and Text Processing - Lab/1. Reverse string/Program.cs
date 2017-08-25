namespace _1.Reverse_string
{
    using System;
    using System.Text;

   public class Program
    {
        public static void Main()
        {
            var inputText = Console.ReadLine();

            var sb = new StringBuilder();

            for (int i = inputText.Length - 1; i >= 0; i--)
            {
                sb.Append(inputText[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}