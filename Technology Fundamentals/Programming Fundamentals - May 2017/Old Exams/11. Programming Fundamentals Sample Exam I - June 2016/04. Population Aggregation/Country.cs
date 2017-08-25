namespace _04.Population_Aggregation
{
    using System.Collections.Generic;

    public class Country
    {
        public Country(string name, int numberOfCities)
        {
            this.Name = name;
            this.NumberOfCities = numberOfCities;
        }

        public string Name { get; set; }
        public int NumberOfCities { get; set; }
    }
}