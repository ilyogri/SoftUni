namespace _04.Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private List<Topping> toping = new List<Topping>();
        private Dough dough;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public List<Topping> Toping
        {
            get
            {
                return this.toping;
            }
            set
            {
                if (value.Count == 0 || value.Count == 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.toping = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }
    }
}