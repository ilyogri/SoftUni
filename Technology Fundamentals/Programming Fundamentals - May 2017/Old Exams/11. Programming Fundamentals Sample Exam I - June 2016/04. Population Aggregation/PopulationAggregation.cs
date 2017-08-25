namespace _04.Population_Aggregation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationAggregation
    {
        public static void Main()
        {
            var countryList = new List<Country>();
            var cityList = new List<City>();

            var input = Console.ReadLine();

            var city = string.Empty;
            var country = string.Empty;

            while (input != "stop")
            {
                var tokens = input.Split('\\');

                if (char.IsLower(tokens[0][0]))
                {
                    city = tokens[0];
                    country = tokens[1];
                }

                else
                {
                    country = tokens[0];
                    city = tokens[1];
                }

                city = string.Concat(city.Where(x => char.IsLetter(x)));
                country = string.Concat(country.Where(x => char.IsLetter(x)));

                var population = long.Parse(tokens[2]);

                var countryIndex = countryList
                    .FindIndex(c => c.Name == country);

                var cityIndex = cityList
                    .FindIndex(c => c.Name == city);

                StoreData(countryIndex, cityIndex, cityList, countryList, city,country, population);

                input = Console.ReadLine();
            }

            PrintResult(countryList, cityList);
        }

        public static void StoreData(int countryIndex, int cityIndex, List<City> cityList
            , List<Country> countryList, string city, string country, long population)
        {
            if (cityIndex >= 0)
            {
                cityList[cityIndex].Population = population;
            }

            else
            {
                var cityClassInfo = new City(city, population);
                cityList.Add(cityClassInfo);
            }

            if (countryIndex >= 0)
            {
                countryList[countryIndex].NumberOfCities++;
            }

            else
            {
                var countryClassInfo = new Country(country, 1);
                countryList.Add(countryClassInfo);
            }
        }

        public static void PrintResult(List<Country> countryList, List<City> cityList)
        {
            var countryCityCount = countryList
                .OrderBy(c => c.Name);

            var cityPopulation = cityList
                .OrderByDescending(c => c.Population);

            foreach (var country in countryCityCount)
            {
                Console.WriteLine($"{country.Name} -> {country.NumberOfCities}");
            }

            foreach (var city in cityPopulation.Take(3))
            {
                Console.WriteLine($"{city.Name} -> {city.Population}");
            }
        }
    }
}