﻿namespace _04.Pizza_Calories
{
    using System;

    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const int BaseCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        private double GetFlourTypeModifier()
        {
            if (this.flourType.ToLower() == "white")
            {
                return 1.5;
            }

            return 1;
        }

        private double GetBakingTechniqueModifier()
        {
            if (this.bakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            if (this.bakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            return 1.0;
        }

        public double CalculateCalories()
        {
            return BaseCalories * this.weight * this.GetBakingTechniqueModifier() * this.GetFlourTypeModifier();
        }
    }
}