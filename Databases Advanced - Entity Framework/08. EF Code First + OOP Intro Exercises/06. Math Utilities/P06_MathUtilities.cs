namespace _06.Math_Utilities
{
    using System;

    public class P06_MathUtilities
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            if (input.Length > 0)
            {
                var operation = input[0];
                var result = 0.0;

                while (operation != "End")
                {
                    if (input.Length == 3)
                    {
                        operation = input[0];
                        var firstNumber = double.Parse(input[1]);
                        var secondNumber = double.Parse(input[2]);

                        switch (operation)
                        {
                            case "Sum":
                                result = MathUtil.Sum(firstNumber, secondNumber);
                                break;
                            case "Multiply":
                                result = MathUtil.Multiply(firstNumber, secondNumber);
                                break;
                            case "Percentage":
                                result = MathUtil.Percentage(firstNumber, secondNumber);
                                break;
                            case "Divide":
                                result = MathUtil.Divide(firstNumber, secondNumber);
                                break;
                            case "Subtract":
                                result = MathUtil.Subtract(firstNumber, secondNumber);
                                break;
                        }

                        Console.WriteLine($"{result:f2}");
                        input = Console.ReadLine().Split();
                    }
                }
            }

            else
            {
                Console.WriteLine("Wrong input!");
            }
        }
    }
}