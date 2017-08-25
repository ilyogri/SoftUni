namespace Problem_2.Vapor_Store
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var currentBalance = double.Parse(Console.ReadLine());
            var gameName = Console.ReadLine();

            var totalBalance = currentBalance;

            while (gameName != "Game Time")
            {
                if (gameName == "RoverWatch")
                {
                    if(currentBalance < 29.99)
                    {
                        Console.WriteLine("Too Expensive");
                        goto restart;
                    }

                    Console.WriteLine("Bought RoverWatch");
                    currentBalance -= 29.99;
                }

                else if (gameName == "Honored 2")
                {
                    if (currentBalance < 59.99)
                    {
                        Console.WriteLine("Too Expensive");
                        goto restart;
                    }

                    Console.WriteLine("Bought Honored 2");
                    currentBalance -= 59.99;
                }

                else if (gameName == "OutFall 4")
                {
                    if (currentBalance < 39.99)
                    {
                        Console.WriteLine("Too Expensive");
                        goto restart;
                    }

                    Console.WriteLine("Bought OutFall 4");
                    currentBalance -= 39.99;
                }

                else if (gameName == "CS: OG")
                {
                    if (currentBalance < 15.99)
                    {
                        Console.WriteLine("Too Expensive");
                        goto restart;
                    }

                    Console.WriteLine("Bought CS: OG");
                    currentBalance -= 15.99;
                }

                else if (gameName == "Zplinter Zell")
                {
                    if (currentBalance < 19.99)
                    {
                        Console.WriteLine("Too Expensive");
                        goto restart;
                    }

                    Console.WriteLine("Bought Zplinter Zell");
                    currentBalance -= 19.99;
                }

                else if (gameName == "RoverWatch Origins Edition")
                {
                    if (currentBalance < 39.99)
                    {
                        Console.WriteLine("Too Expensive");
                        goto restart;
                    }

                    Console.WriteLine("Bought RoverWatch Origins Edition");
                    currentBalance -= 39.99;
                }

                else
                {
                    Console.WriteLine("Not Found");
                }

                if(currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                restart:
                gameName = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${(totalBalance- currentBalance):f2}. Remaining: ${currentBalance:f2}");
        }
    }
}