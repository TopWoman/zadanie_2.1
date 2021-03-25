using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    public class Product
    {
        public string Name;
        private double _weight;
        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0) _weight = 0;
                else _weight = value;
            }
        }
        public bool IsFragile { get; set; } // галка хрупкий/нехрупкий товар
        
        public int DimensionsId { get; set; }
        public Dimensions Dimensions { get; set; }

        private double _price;
        public double Price 
        { 
            get => _price;  
            set 
            {
                if (value < 0) _price = 1;
                else _price = value;
            }
        }

        public Product (string name, double weight, bool isFragile, Dimensions dimensions, double price)
        {
            Name = name;
            Weight = weight;
            IsFragile = isFragile;
            Dimensions = dimensions;
            Price = price;
        }

    }
}
