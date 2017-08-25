namespace _04.SoftUni_Coffee_Supplies
{
   public class Coffee
    {
        public Coffee(string type, decimal quantity)
        {
            this.Type = type;
            this.Quantity = quantity;
        }

        public string Type { get; set; }
        public decimal Quantity { get; set; }
    }
}