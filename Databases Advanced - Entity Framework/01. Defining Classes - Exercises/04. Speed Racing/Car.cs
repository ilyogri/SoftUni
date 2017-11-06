namespace _04.Speed_Racing
{
    public class Car
    {
        public Car (string model, double fuelAmount, double fuelConsumptionFor1Km, int distanceTravelled)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1Km = fuelConsumptionFor1Km;
            this.DistanceTravelled = distanceTravelled;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionFor1Km { get; set; }

        public int DistanceTravelled { get; set; }

        public double Drive(double distanceTravelled, double fuelConsumptionFor1Km)
        {
            return distanceTravelled * fuelConsumptionFor1Km;
        }

        public string ToString()
        {
            return $"{Model} {FuelAmount:f2} {DistanceTravelled}";
        }
    }
}