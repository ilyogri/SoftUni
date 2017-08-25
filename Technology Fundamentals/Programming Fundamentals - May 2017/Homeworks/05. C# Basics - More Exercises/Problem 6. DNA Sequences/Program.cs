namespace Problem_6.DNA_Sequences
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var matchSum = int.Parse(Console.ReadLine());

            var tempSum = 0;
            var newLineCounter = 0;

            for (char i = 'A'; i <= 'T'; i++)
            {
                for (char j = 'A'; j <= 'T'; j++)
                {
                    for (char k = 'A'; k <= 'T'; k++)
                    {
                        var chars = string.Concat(i.ToString() + j.ToString() + k.ToString());

                        foreach (var letter in chars)
                        {
                            switch (letter)
                            {
                                case 'A':
                                    tempSum += 1;
                                    break;
                                case 'C':
                                    tempSum += 2;
                                    break;
                                case 'G':
                                    tempSum += 3;
                                    break;
                                case 'T':
                                    tempSum += 4;
                                    break;
                                default:
                                    goto NotANucleotide;
                            }
                        }

                        if (tempSum >= matchSum)
                        {
                            if (newLineCounter % 4 == 0 && newLineCounter != 0)
                            {
                                Console.WriteLine();
                            }

                            Console.Write($"O{i}{j}{k}O ");
                        }

                        else
                        {
                            if (newLineCounter % 4 == 0 && newLineCounter != 0)
                            {
                                Console.WriteLine();
                            }

                            Console.Write($"X{i}{j}{k}X ");
                        }

                        newLineCounter++;
                        NotANucleotide:
                        tempSum = 0;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}