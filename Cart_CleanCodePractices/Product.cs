using System;
using System.Collections.Generic;
using System.Text;

namespace Cart_CleanCodePractices
{
    public class Product
    {
        public String Name { get; set;}
        public Double Price { get; set; }

        public Category category { get; set; }

        public Product(String name, Double price, Category cat)
        {
            Name = name;
            Price = price;
            category = cat;
        }
    }
}
