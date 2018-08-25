using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonStore.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
