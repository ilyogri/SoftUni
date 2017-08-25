namespace Problem_03.Safe_Manipulation
{
    using System;
    using System.Linq;

    public class SafeManipulation
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(' ');

            var command = Console.ReadLine().Split(' ');

            while (command[0] != "END")
            {
                if (command[0] == "Reverse")
                {
                    Array.Reverse(words);
                }

                else if (command[0] == "Distinct")
                {
                    words = words.Distinct().ToArray();
                }

                else if (command[0] == "Replace")
                {
                    var index = int.Parse(command[1]);

                    if (!(index > words.Length - 1 || index < 0))
                    {
                        var wordToReplace = command[2];
                        words[index] = wordToReplace;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine().Split(' ');
            }

            Console.WriteLine(string.Join(", ", words));

        }
    }
}