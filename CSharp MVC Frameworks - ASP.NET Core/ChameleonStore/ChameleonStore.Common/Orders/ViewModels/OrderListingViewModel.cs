using System;

namespace ChameleonStore.Common.Orders.ViewModels
{
    public class OrderListingViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int Products { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
