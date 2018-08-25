﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonStore.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}