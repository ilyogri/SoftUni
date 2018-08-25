using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}
