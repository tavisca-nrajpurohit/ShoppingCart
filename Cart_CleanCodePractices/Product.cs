using System;
using System.Collections.Generic;
using System.Text;

namespace Cart_CleanCodePractices
{
    public class Product
    {
        public String Name { get; set;}
        public Double Price { get; set; }

        public Product(String name, Double price)
        {
            Name = name;
            Price = price;
        }
    }
}
