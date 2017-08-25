namespace _06.Email_Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class EmailStatistics
    {
        public static void Main()
        {
            var emailsCount = int.Parse(Console.ReadLine());
            var domainUsername = new Dictionary<string, List<string>>();

            var regex = new Regex(@"^([A-Za-z]{5,})@([a-z]{3,}(\.bg|\.com|\.org))$");

            for (int i = 0; i < emailsCount; i++)
            {
                var emailInput = Console.ReadLine();

                var match = regex.Match(emailInput);
                if (match.Success)
                {
                    var currentUsername = match.Groups[1].ToString();
                    var currentDomain = match.Groups[2].ToString();

                    if (domainUsername.ContainsKey(currentDomain))
                    {
                        if (domainUsername[currentDomain].Contains(currentUsername))
                        {
                            continue;
                        }

                        domainUsername[currentDomain].Add(currentUsername);
                    }

                    else
                    {
                        domainUsername[currentDomain] = new List<string>();
                        domainUsername[currentDomain].Add(currentUsername);
                    }
                }
            }

            PrintResult(domainUsername);
        }

        public static void PrintResult(Dictionary<string, List<string>> domainUsername)
        {
            var sorted = domainUsername
                .OrderByDescending(d => d.Value.Count());

            foreach (var domain in sorted)
            {
                Console.WriteLine(domain.Key + ":");

                foreach (var username in domain.Value)
                {
                    Console.WriteLine($"### {username}");
                }
            }
        }
    }
}