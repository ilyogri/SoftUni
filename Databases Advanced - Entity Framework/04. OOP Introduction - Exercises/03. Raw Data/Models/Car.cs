namespace _03.Raw_Data
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires = new Tire[4];

        public Car(string model, Engine engine, Cargo ccargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = ccargo;
            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }
    }
}