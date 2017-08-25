namespace _17.Print_Part_of_the_ASCII_Table
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                char character = (char)i;
                Console.Write(character.ToString() + " ");
            }

            Console.WriteLine();
        }
    }
}