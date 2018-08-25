using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChameleonStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Items = new List<OrderItem>();
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice => this.Items.Sum(i => i.ProductPrice * i.Quantity);

        public ICollection<OrderItem> Items { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate => this.OrderDate.AddDays(7);

        public string UserId { get; set; }

        public User User { get; set; }
    }
}