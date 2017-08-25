namespace _05.Parking_Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingValidation
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, string>();

            for (int i = 0; i < linesCount; i++)
            {
                var registerInput = Console.ReadLine().Split(' ');

                var command = registerInput[0];
                var username = registerInput[1];

                if (command == "register")
                {
                    var licensePlateNumber = registerInput[2];

                    if (dict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {dict[username]}");
                    }

                    else if (!IsLicencePlateValid(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                    }

                    else if (dict.ContainsValue(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                    }

                    else
                    {
                        dict.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }

                else
                {
                    if (!dict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }

                    else
                    {
                        dict.Remove(username);
                        Console.WriteLine($"user {username} unregistered successfully");
                    }
                }
            }

            foreach (var username in dict)
            {
                Console.WriteLine($"{username.Key} => {username.Value}");
            }
        }

        public static bool IsLicencePlateValid(string licensePlateNumber)
        {
            if (licensePlateNumber.Length == 8
                && licensePlateNumber.Take(2).All(char.IsUpper)
                && licensePlateNumber.Skip(2).Take(4).All(char.IsDigit)
                && licensePlateNumber.Skip(6).Take(2).All(char.IsUpper))
            {
                return true;
            }

            return false;
        }
    }
}