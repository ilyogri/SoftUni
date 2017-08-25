namespace _08.Personal_Exception
{
    using System;

    public class PersonalException
    {
        public static void Main()
        {
            var numberAsString = Console.ReadLine();

            while (true)
            {
                try
                {
                    var positiveNumber = uint.Parse(numberAsString);
                    Console.WriteLine(positiveNumber);
                }

                catch (Exception)
                {
                    Console.WriteLine("My first exception is awesome!!!");
                    return;
                }

                numberAsString = Console.ReadLine();
            }
        }
    }
}