namespace _04.Pizza_Calories
{
    using System;

    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;
        private const int BaseCalories = 2;

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            } 
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        private double GetToppingTypeModifier()
        {
            switch (this.toppingType.ToLower())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
            }
            //case if its "sauce"
            return 0.9;
        }

        public double CalculateCalories()
        {
            return BaseCalories * this.weight * this.GetToppingTypeModifier();
        }
    }
}