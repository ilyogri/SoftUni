namespace _2.Change_List
{
    using System;
    using System.Linq;

    public class ChangeList
    {
        public static void Main()
        {
            var listOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var commandInput = Console.ReadLine();

            while (commandInput != "Even" && commandInput != "Odd")
            {
                var splittedCommand = commandInput.Split(' ');
                var currentCommand = splittedCommand[0];
                var element = int.Parse(splittedCommand[1]);

                if (currentCommand == "Insert")
                {
                    var index = int.Parse(splittedCommand[2]);

                    listOfNumbers.Insert(index, element);
                }

                else
                {
                    listOfNumbers.RemoveAll(x => x == element);
                }

                commandInput = Console.ReadLine();
            }

            if (commandInput == "Even")
            {
                listOfNumbers.RemoveAll(x => x % 2 != 0);
            }

            else
            {
                listOfNumbers.RemoveAll(x => x % 2 == 0);
            }

            Console.WriteLine(string.Join(" ", listOfNumbers));
        }
    }
}