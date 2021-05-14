using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
        
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Volume { get; set; }

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

        public Product (string name, double weight, bool isFragile, double height, 
            double width, double length , double price)
        {
            Name = name;
            Weight = weight;
            IsFragile = isFragile;
            Height = height;
            Width = width;
            Length = length;
            Volume = Height * Width * Length;
            Price = price;
        }

    }
}
