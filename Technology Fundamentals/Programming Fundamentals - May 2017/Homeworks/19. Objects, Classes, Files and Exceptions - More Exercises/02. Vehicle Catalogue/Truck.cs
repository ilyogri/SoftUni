namespace _02.Vehicle_Catalogue
{
    public class Truck
    {
        public Truck(string model, string color, int horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}