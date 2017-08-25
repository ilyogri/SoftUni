namespace _1.Blank_Receipt
{
    using System;

   public class Program
    {
        public static void Main()
        {
            PrintReceipt();
        }

        public static void PrintReceipt()
        {
            PrintHeader();
            PrintBody();
            PrintFooter();
        }

        public static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }

        public static void PrintBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        public static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
    }
}