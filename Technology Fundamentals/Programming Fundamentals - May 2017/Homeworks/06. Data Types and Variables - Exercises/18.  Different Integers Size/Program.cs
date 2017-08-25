namespace _18.Different_Integers_Size
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string numberStr = Console.ReadLine();

            long number = 0;

            try
            {
                number = long.Parse(numberStr);

            }

            catch (Exception)
            {
                Console.WriteLine($"{numberStr} can't fit in any type");
                return;
            }

            List<string> capableDataType = new List<string> { };
            capableDataType.Add($"{numberStr} can fit in:");

            if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
            {
                capableDataType.Add("* sbyte");
            }

            if (number >= byte.MinValue && number <= byte.MaxValue)
            {
                capableDataType.Add("* byte");
            }

            if (number >= short.MinValue && number <= short.MaxValue)
            {
                capableDataType.Add("* short");
            }

            if (number >= ushort.MinValue && number <= ushort.MaxValue)
            {
                capableDataType.Add("* ushort");
            }

            if (number >= int.MinValue && number <= int.MaxValue)
            {
                capableDataType.Add("* int");
            }

            if (number >= uint.MinValue && number <= uint.MaxValue)
            {
                capableDataType.Add("* uint");
            }

            if (number >= long.MinValue && number <= long.MaxValue)
            {
                capableDataType.Add("* long");
            }

            Console.WriteLine(string.Join("\n", capableDataType));
        }
    }
}