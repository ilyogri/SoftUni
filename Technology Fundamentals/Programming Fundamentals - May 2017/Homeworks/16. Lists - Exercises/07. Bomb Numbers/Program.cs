namespace _5.Bomb_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var listOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var specialBombNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var power = specialBombNumbers[1];
            var specialNumber = specialBombNumbers[0];

            for (int index = 0; index < listOfNumbers.Count(); index++)
            {
                if (listOfNumbers[index] == specialNumber)
                {
                    //if the "power" is bigger or equal than the numbers count at right
                    if (index + power >= listOfNumbers.Count())
                    {
                        //removes the numbers at left
                        listOfNumbers.RemoveRange(index - power, power);
                        //then finds the index of the "special number" and remove all of the elements at right
                        listOfNumbers.RemoveRange(listOfNumbers.IndexOf(specialNumber), listOfNumbers.Count() - (index - power));
                    }

                    //if the "power" is smaller than the left numbers count
                    else if (index - power < 0)
                    {
                        //removes all possible numbers left from the "special number" + the "special number"
                        listOfNumbers.RemoveRange(0, index + 1);

                        //removes the numbers at right from the "special number"
                        if (listOfNumbers.Count() > 0)
                        {
                            listOfNumbers.RemoveRange(0, power);
                        }
                    }

                    //if enough numbers at left and right are possible to remove
                    else
                    {
                        listOfNumbers.RemoveRange(index - power, power * 2 + 1);
                    }

                    //the index must be reset because of the new "listOfNumbers" count
                    index = 0;
                }
            }

            Console.WriteLine(listOfNumbers.Sum());
        }
    }
}


/* another working solution
 * 
using System;
using System.Collections.Generic;
using System.Linq;

public class BombNumbers
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int[] bombArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int bombNumber = bombArgs[0];
        int power = bombArgs[1];

        int indexOfBombNum = numbers.IndexOf(bombNumber);

        while (indexOfBombNum != -1)
        {
            int leftPower = indexOfBombNum < power ? indexOfBombNum : power;
            int leftIndex = indexOfBombNum - power < 0 ? 0 : indexOfBombNum - power;
            int rightPower = indexOfBombNum + power > numbers.Count ? numbers.Count - indexOfBombNum - 1 : power;

            numbers.RemoveRange(leftIndex, leftPower + rightPower + 1);
            indexOfBombNum = numbers.IndexOf(bombNumber);
        }

        Console.WriteLine(numbers.Sum());
    }
}*/
