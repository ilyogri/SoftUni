using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').ToList();
            var index = int.Parse(Console.ReadLine());
            var count = int.Parse(Console.ReadLine());

            var sortList = new List<string>();

            for (int i = index; i < count + index; i++)
            {
                sortList.Add(numbers[i]);
            }

            sortList.Sort();

            numbers.RemoveRange(index, count);
            numbers.InsertRange(index, sortList);
            //for (int i = index; i < count + index; i++)
            //{
            //    numbers[i] = sortList[i];
            //}


           //umbers.RemoveRange(index, count);
         // numbers.InsertRange(index, sortList);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
