namespace _7.Sales_Report
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var list = new List<Sale>();
            list = StoreEverySaleData(list, linesCount);

            var result = new SortedDictionary<string, double>();
            result = StoreTotalSalesByTown(list, result);

            PrintResult(result);
        }

        public static List<Sale> StoreEverySaleData(List<Sale> list, int linesCount)
        {
            for (int i = 0; i < linesCount; i++)
            {
                var salesInput = Console.ReadLine().Split(' ');

                var salesClass = new Sale
                {
                    Town = salesInput[0],
                    Product = salesInput[1],
                    Price = double.Parse(salesInput[2]),
                    Quantity = double.Parse(salesInput[3]),
                };

                list.Add(salesClass);
            }

            return list;
        }

        public static SortedDictionary<string, double> StoreTotalSalesByTown(List<Sale> list, SortedDictionary<string, double> result)
        {
            foreach (var data in list)
            {
                if (!result.ContainsKey(data.Town))
                {
                    result[data.Town] = 0;
                }

                result[data.Town] += data.Price * data.Quantity;
            }

            return result;
        }

        public static void PrintResult(SortedDictionary<string, double> result)
        {
            foreach (var townAndSales in result)
            {
                Console.WriteLine("{0} -> {1:f2}", townAndSales.Key, townAndSales.Value);
            }
        }
    }
}