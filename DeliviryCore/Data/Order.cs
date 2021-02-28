using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class Order
    {

        public Client Client { get; set; } // клиент
        public string Address1 { get; set; } // адресс1
        public string Address2 { get; set; } // адрес 2

        public readonly DateTime OrderCreationDate; //дата создания заказа
        public DateTime OrderCompletionDate { get; set; } //дата выполнения заказа
        public double weight; //вес
        public double Weight //вес
        {
            get
            {
                double sum = 0;
                foreach (var OrderLine in OrderLines)
                {
                    sum += OrderLine.Product.Weight;
                }
                return sum;
            }
            set
            {
                if (value < 0) weight = 0;
                else weight = value;
            }
        }
        private static int nextId;
        public readonly int ID;

        //----------------------------------------------------------------------------------------------///
        //Поменять это на OrderLine. Везде, где надо сделать замену.
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();// список товаров (коллекция)

        //----------------------------------------------------------------------------------------------///
        public double Volume 
        {
            get
            {
                double sum = 0;
                foreach (var OrderLine in OrderLines)
                {
                    sum += OrderLine.Product.Dimensions.Volume;
                }
                return sum;
            }
        }

        public double distance;
        public double Distance  // расстояние
        { 
            get => distance; 
            set
            {
                if (value < 0) distance = 0;
                else distance = value;
            }
        }
        public OrderStatus Status { get; set; } // статус
        public bool IsFragile { get; set; } // хрупкий или нет

        public Order(Client client, string address1, string address2, double weight,
                    double distance, OrderStatus status, bool isfragile)
        {
            Client = client;
            Address1 = address1;
            Address2 = address2;
            Weight = weight;
            Distance = distance;
            Status = status;
            IsFragile = isfragile;
            ID = Interlocked.Increment(ref nextId);
            OrderCreationDate = DateTime.UtcNow;
        }

        //TODO по ид добавляет строку в заказ. Как вариант можно сделать этот метод в самом заказе, тогда в параметрах не будет id.
        //добавление продуктов и их кол-во
        public void AddOrderLine( Product product, int count)
        {
            OrderLine orderLine = new OrderLine()
            {
                Product = product,
                Count = count
            };

            OrderLines.Add(orderLine);

        }

    }
}
