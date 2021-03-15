using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    public class Product
    {
        public string Name;
        private double weight;
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0) weight = 0;
                else weight = value;
            }
        }
        public bool IsFragile { get; set; } // галка хрупкий/нехрупкий товар
        public Dimensions Dimensions { get; set; }

        private double price;
        public double Price 
        { 
            get => price;  
            set 
            {
                if (value < 0) price = 1;
                else price = value;
            }
        }

        public Product (string name, double weight, bool isfragile, Dimensions dimensions, double price)
        {
            Name = name;
            Weight = weight;
            IsFragile = isfragile;
            Dimensions = dimensions;
            Price = price;
        }

    }
}
