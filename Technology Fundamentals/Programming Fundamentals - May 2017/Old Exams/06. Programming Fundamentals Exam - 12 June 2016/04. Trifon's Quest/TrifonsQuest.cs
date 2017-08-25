namespace _04.Trifon_s_Quest
{
    using System;
    using System.Linq;

    public class TrifonsQuest
    {
        public static void Main()
        {
            var trifonsHealth = long.Parse(Console.ReadLine());
            var matrixSize = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long rows = matrixSize[0];
            long col = matrixSize[1];
            var matrix = new char[rows, col];

             StoreCommands(matrix, rows, col);

            var indexOfDeath = string.Empty;
            long turns = 0;

            for (int c = 0; c < col; c++)
            {
                if (c % 2 == 0)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        var command = matrix[r, c];

                        if(command == 'T')
                        {
                            turns += 2;
                        }

                        else if (command != 'E')
                        {
                            trifonsHealth = GetHealth(command, turns, trifonsHealth);
                        }

                        turns++;

                        if (trifonsHealth <= 0)
                        {
                            Console.WriteLine($"Died at: [{r}, {c}]");
                            return;
                        }
                    }
                }

                else
                {
                    for (long r = rows - 1; r >= 0; r--)
                    {
                        var command = matrix[r, c];

                        if (command == 'T')
                        {
                            turns += 2;
                        }

                        else if (command != 'E')
                        {
                            trifonsHealth = GetHealth(command, turns, trifonsHealth);
                        }

                        turns++;

                        if (trifonsHealth <= 0)
                        {
                            Console.WriteLine($"Died at: [{r}, {c}]");
                            return;
                        }
                    }
                }
            }
                Console.WriteLine($"Quest completed!");
                Console.WriteLine($"Health: {trifonsHealth}");
                Console.WriteLine($"Turns: {turns}");
        }

        

        public static void StoreCommands(char[,] matrix, long row, long col)
        {
            for (int i = 0; i < row; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }

        public static long GetHealth(char command, long turns, long health)
        {
            if (command == 'F')
            {
                health -= turns / 2;
            }

            else if (command == 'H')
            {
                health += turns / 3;
            }

            return health;
        }
    }
}