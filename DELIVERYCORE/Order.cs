using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Order
    {
        public Client Client { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public double weight; //вес
        public double Weight //вес
        { 
            get => weight;
            set
            {
                if (value < 0) weight = 0;
                else weight = value;
            }
        } 
        public Product Product { get; set; }
        public double distance;
        public double Distance 
        { 
            get => distance; 
            set
            {
                if (value < 0) distance = 0;
                else distance = value;
            }
        }
        public OrderStatus Status { get; set; }
        public bool IsFragile { get; set; }

        public Order(Client client, string address1, string address2, double weight, Product product,
                    double distance, OrderStatus status, bool isfragile)
        {
            Client = client;
            Address1 = address1;
            Address2 = address2;
            Weight = weight;
            Product = product;
            Distance = distance;
            Status = status;
            IsFragile = isfragile;

        }
    }
}
