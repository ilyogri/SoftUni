namespace Problem_02.Manipulate_Array
{
    using System;
    using System.Linq;

    public class ManipulateArray
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(' ');
            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var command = Console.ReadLine().Split(' ');

                if(command[0] == "Reverse")
                {
                    Array.Reverse(words);
                }

                else if (command[0] == "Distinct")
                {
                   words = words.Distinct().ToArray();
                }

                else if(command[0] == "Replace")
                {
                    var index = int.Parse(command[1]);
                    var wordToReplace = command[2];

                    words[index] = wordToReplace;
                }
            }

            Console.WriteLine(string.Join(", ",words));
        }
    }
}