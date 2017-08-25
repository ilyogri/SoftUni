using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysName = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var day = int.Parse(Console.ReadLine());

            if (day > 0 && day <= daysName.Length)
            {
                Console.WriteLine(daysName[day - 1]);
            }

            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}