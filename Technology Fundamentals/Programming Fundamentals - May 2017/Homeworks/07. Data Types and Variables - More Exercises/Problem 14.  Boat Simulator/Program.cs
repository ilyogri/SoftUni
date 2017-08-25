namespace Problem_14.Boat_Simulator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstBoatChar = Console.ReadLine().ToCharArray();
            var secondBoatChar = Console.ReadLine().ToCharArray();
            var linesCount = int.Parse(Console.ReadLine());

            var firstBoatMoves = 0;
            var secondBoatMoves = 0;

            for (int i = 1; i <= linesCount; i++)
            {
                var input = Console.ReadLine();

                if (input == "UPGRADE")
                {
                    firstBoatChar[0] = (char)(firstBoatChar[0] + 3);
                    secondBoatChar[0] = (char)(secondBoatChar[0] + 3);
                }

                else
                {
                    if (i % 2 == 0)
                    {
                        secondBoatMoves += input.Length;
                    }

                    else
                    {
                        firstBoatMoves += input.Length;
                    }
                }

                if (firstBoatMoves >= 50 || secondBoatMoves >= 50)
                {
                    break;
                }
            }

            var winner = firstBoatMoves > secondBoatMoves?
                firstBoatChar : secondBoatChar;

            Console.WriteLine(winner);
        }
    }
}