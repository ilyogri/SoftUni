namespace _04.Winning_Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WinningTicket
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in input)
            {
                if (ticket.Length == 20)
                {
                    var regex = new Regex(@"\${6,}|\@{6,}|\^{6,}|\#{6,}");

                    var leftHalfSymbolsMatch = regex.Match(ticket.Substring(0, 10));
                    var rightHalfSymbolsMatch = regex.Match(ticket.Substring(10));
                    var minLen = Math.Min(leftHalfSymbolsMatch.Length, rightHalfSymbolsMatch.Length);

                    if (leftHalfSymbolsMatch.Success && rightHalfSymbolsMatch.Success)
                    {
                        var leftPart = leftHalfSymbolsMatch.Value.Substring(0, minLen);
                        var rightPart = rightHalfSymbolsMatch.Value.Substring(0, minLen);

                        if (leftPart == rightPart)
                        {
                            if (leftPart.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftPart.Length}{leftPart.Substring(0, 1)} Jackpot!");
                            }

                            else
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftPart.Length + "" + leftPart.Substring(0, 1)}");
                            }
                        }

                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }

                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}