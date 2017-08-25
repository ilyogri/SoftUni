namespace _03.Matrix_Operator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatrixOperator
    {
        public static void Main()
        {
            var rowsCount = int.Parse(Console.ReadLine());

            var matrix = new decimal[rowsCount][];
            StoreNumbers(matrix, rowsCount);

            var commands = Console.ReadLine();
            while (commands != "end")
            {
                var tokens = commands.Split();
                var command = tokens[0];

                switch (command)
                {
                    case "remove":
                        var type = tokens[1];
                        var rowOrColumn = tokens[2];
                        var position = int.Parse(tokens[3]);

                        switch (type)
                        {
                            case "even":
                                RemoveEvenNumbers(rowOrColumn, matrix, position);
                                break;

                            case "odd":
                                RemoveOddNumbers(rowOrColumn, matrix, position);
                                break;

                            case "positive":
                                RemovePositiveNumbers(rowOrColumn, matrix, position);
                                break;

                            case "negative":
                                RemoveNegativeNumbers(rowOrColumn, matrix, position);
                                break;
                        }

                        break;

                    case "swap":
                        var firstRow = int.Parse(tokens[1]);
                        var secondRow = int.Parse(tokens[2]);

                        SwapMatrixRows(matrix, firstRow, secondRow);
                        break;

                    case "insert":
                        var row = int.Parse(tokens[1]);
                        var element = decimal.Parse(tokens[2]);

                        MatrixInsertNumber(matrix, row, element);
                        break;
                }

                commands = Console.ReadLine();
            }

            PrintResult(matrix);
        }

        public static void PrintResult(decimal[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                Console.WriteLine(string.Join(" ", matrix[r]));
            }
        }

        public static void MatrixInsertNumber(decimal[][] matrix, int row, decimal element)
        {
            var list = new List<decimal>(matrix[row]);

            list.Insert(0, element);
            matrix[row] = list.ToArray();
        }

        public static void SwapMatrixRows(decimal[][] matrix, int firstRow, int secondRow)
        {
            var firstRowNumbers = matrix[firstRow];

            matrix[firstRow] = matrix[secondRow];
            matrix[secondRow] = firstRowNumbers;
        }

        public static void RemoveNegativeNumbers(string rowOrColumn, decimal[][] matrix, int position)
        {
            if (rowOrColumn == "row")
            {
                matrix[position] = matrix[position].Where(x => x >= 0).ToArray();
            }

            else
            {
                for (int r = 0; r < matrix.Length; r++)
                {
                    var newList = new List<decimal>(matrix[r]);

                    if (position < newList.Count && newList[position] < 0)
                    {
                        newList.RemoveAt(position);
                        matrix[r] = newList.ToArray();
                    }
                }
            }
        }

        public static void RemoveOddNumbers(string rowOrColumn, decimal[][] matrix, int position)
        {
            if (rowOrColumn == "row")
            {
                matrix[position] = matrix[position].Where(x => x % 2 == 0).ToArray();
            }

            else
            {
                for (int r = 0; r < matrix.Length; r++)
                {
                    var newList = new List<decimal>(matrix[r]);

                    if (position < newList.Count && newList[position] % 2 != 0)
                    {
                        newList.RemoveAt(position);
                        matrix[r] = newList.ToArray();
                    }
                }
            }
        }

        public static void RemovePositiveNumbers(string rowOrColumn, decimal[][] matrix, int position)
        {
            if (rowOrColumn == "row")
            {
                matrix[position] = matrix[position].Where(x => x < 0).ToArray();
            }

            else
            {
                for (int r = 0; r < matrix.Length; r++)
                {
                    var newList = new List<decimal>(matrix[r]);

                    if (position < newList.Count && newList[position] >= 0)
                    {
                        newList.RemoveAt(position);
                        matrix[r] = newList.ToArray();
                    }
                }
            }
        }

        public static void RemoveEvenNumbers(string rowOrColumn, decimal[][] matrix, int position)
        {
            if (rowOrColumn == "row")
            {
                matrix[position] = matrix[position].Where(x => x % 2 != 0).ToArray();
            }

            else
            {
                for (int r = 0; r < matrix.Length; r++)
                {
                    var newList = new List<decimal>(matrix[r]);

                    if (position < newList.Count && newList[position] % 2 == 0)
                    {
                        newList.RemoveAt(position);
                        matrix[r] = newList.ToArray();
                    }
                }
            }
        }

        public static void StoreNumbers(decimal[][] matrix, decimal rowsCount)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                var numbers = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

                matrix[i] = numbers;
            }
        }
    }
}