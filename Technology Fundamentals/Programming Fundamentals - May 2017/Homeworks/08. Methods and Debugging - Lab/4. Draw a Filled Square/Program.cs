namespace _4.Draw_a_Filled_Square
{
    using System;

    public class DrawAFilledSquare
    {
        public static void Main()
        {
            int figureLength = int.Parse(Console.ReadLine());

            PrintTopAndBotRows(figureLength);
            PrintMidOfSquare(figureLength);
            PrintTopAndBotRows(figureLength);
        }

        public static void PrintTopAndBotRows(int number)
        {
            Console.Write(new string('-', 2 * number) + "\n");
        }

        public static void PrintMidOfSquare(int number)
        {
            for (int i = 0; i < number - 2; i++)
            {
                Console.Write("-");

                for (int j = 0; j < number - 1; j++)
                {
                    Console.Write(@"\/");
                }

                Console.Write("-" + "\n");
            }
        }
    }
}