using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    public class Order
    {

        [NotMapped]
        public Client Client // клиент
        {
            get
            {
                using (AppContext dbContext = new AppContext())
                {
                    return dbContext.Clients.Find(ClientId);
                }
            }
        }
        public int ClientId { get; set; }
        public string Address1 { get; set; } // адресс1
        public string Address2 { get; set; } // адрес 2

        public readonly DateTime OrderCreationDate; //дата создания заказа
        public DateTime OrderCompletionDate { get; set; } //дата выполнения заказа
        private double _weight; //вес
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
                if (value < 0) _weight = 0;
                else _weight = value;
            }
        }
        public int Id { get; set; }

        //----------------------------------------------------------------------------------------------///
        //Поменять это на OrderLine. Везде, где надо сделать замену.
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();// список товаров (коллекция)

        //----------------------------------------------------------------------------------------------///
        public double Volume
        {
            get
            {
                double sum = 0;
                foreach (var orderLine in OrderLines)
                {
                    sum += orderLine.Product.Volume;
                }
                return sum;
            }
        }

        private double _distance;
        public double Distance  // расстояние
        {
            get => _distance;
            set
            {
                if (value < 0) _distance = 0;
                else _distance = value;
            }
        }
        public OrderStatus Status { get; set; } // статус
        public bool IsFragile { get; set; } // хрупкий или нет

        public Order(int clientId, string address1, string address2, double weight,
                    double distance, OrderStatus status, bool isFragile)
        {
            ClientId = clientId;
            Address1 = address1;
            Address2 = address2;
            Weight = weight;
            Distance = distance;
            Status = status;
            IsFragile = isFragile;
            OrderCreationDate = DateTime.UtcNow;
        }

        //TODO по ид добавляет строку в заказ. Как вариант можно сделать этот метод в самом заказе, тогда в параметрах не будет ID.
        //добавление продуктов и их кол-во
        public void AddOrderLine(Product product, int count)
        {
            OrderLine orderLine = new OrderLine(product.Id, count);

            OrderLines.Add(orderLine);

        }

    }
}
