namespace _03.Portal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Portal
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new char[matrixSize][];
            FillTheMatrix(matrix, matrixSize);
            //var list = new List<string>();

            //for (int i = 0; i < matrixSize; i++)
            //{
            //    var actualMatrix = Console.ReadLine();
            //    list.Add(actualMatrix);
            //}

            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i].Length != matrixSize)
            //    {
            //        list[i] += string.Concat(Enumerable.Repeat(' ', matrixSize - list[i].Length));
            //    }
            //}

            //for (int i = 0; i < list.Count; i++)
            //{
            //    matrix[i] = list[i].ToArray();
            //}

            //var start = string.Concat(list.Where(x => x.Contains('S')));
            //var row = list.IndexOf(start);
            //var column = start.IndexOf('S');
            long jumpsCount = 0;
            var directions = Console.ReadLine();

            var startPosition = GetStartPosition(matrix);
            var row = startPosition[0];
            var column = startPosition[1];

            foreach (var direction in directions)
            {
                if (direction == 'D')
                {
                    row++;
                    if (row >= matrix.Length)
                    {
                        row = 0;
                    }

                    while (matrix[row][column] == ' ')
                    {
                        row++;
                        if (row >= matrix.Length)
                        {
                            row = 0;
                        }
                    }
                }

                else if (direction == 'U')
                {
                    row--;
                    if (row < 0)
                    {
                        row = matrix.Length - 1;
                    }

                    while (matrix[row][column] == ' ')
                    {
                        row--;
                        if (row < 0)
                        {
                            row = matrix.Length - 1;
                        }
                    }
                }

                else if (direction == 'L')
                {
                    column--;
                    if (column < 0)
                    {
                        column = matrix[row].Length - 1;
                    }

                    while (matrix[row][column] == ' ')
                    {
                        column--;
                        if (column < 0)
                        {
                            column = matrix[row].Length - 1;
                        }
                    }
                }

                else //if (direction == 'R')
                {
                    column++;
                    if (column >= matrix[row].Length)
                    {
                        column = 0;
                    }

                    while (matrix[row][column] == ' ')
                    {
                        column++;
                        if (column >= matrix[row].Length)
                        {
                            column = 0;
                        }
                    }
                }

                jumpsCount++;

                if (matrix[row][column] == 'E')
                {
                    Console.WriteLine($"Experiment successful. {jumpsCount} turns required.");
                    return;
                }
            }

            Console.WriteLine($" Robot stuck at {row} {column}. Experiment failed.");
        }

        private static void FillTheMatrix(char[][] matrix, int size)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                List<char> colsElements = Console.ReadLine().ToCharArray().ToList();

                while (colsElements.Count < size)
                {
                    colsElements.Add('X');
                }

                matrix[row] = colsElements.ToArray();
            }
        }

        private static int[] GetStartPosition(char[][] matrix)
        {
            int[] position = new int[2] { 0, 0 };
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        position[0] = row;
                        position[1] = col;
                        return position;
                    }
                }
            }

            return position;
        }
    }
}