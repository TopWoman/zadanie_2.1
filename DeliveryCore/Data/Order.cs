using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DeliveryCore.Data
{
    public class Order : IOrder<OrderLine>
    {

        [NotMapped]
        public Client Client // клиент
        {
            get
            {
                using AppContext dbContext = new AppContext();
                return dbContext.Clients.Find(ClientId);
            }
        }
        public int ClientId { get; set; }
        public string Address1 { get; set; } // адрес 1
        public string Address2 { get; set; } // адрес 2
        public DateTime CreateDate { get; set; } //дата создания заказа

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
        }
        public int Id { get; set; }
        public List<OrderLine> OrderLines
        {
            get
            {
                using AppContext dbContext = new AppContext();
                return dbContext.OrderLines.Where(ordLine => ordLine.OrderId == Id).ToList();
            }

        }

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
        public void RemoveOrderLine(OrderLine orderLine)
        {
            using AppContext dbContext = new AppContext();
            if (orderLine == null)
                throw new ArgumentNullException(nameof(orderLine));
            dbContext.Attach(orderLine);
            dbContext.OrderLines.Remove(orderLine);
            dbContext.SaveChanges();
        }

        public void RemoveOrderLine(int id)
        {
            using AppContext dbContext = new AppContext();
            OrderLine lineToDelete = dbContext.OrderLines.Find(id);
            if (lineToDelete != null)
            {
                dbContext.OrderLines.Remove(lineToDelete);
                dbContext.SaveChanges();
            }
            else throw new ArgumentException($"There is no Order line with id = {id}.");
        }

        public Order(int clientId, string address1, string address2,
                    double distance, OrderStatus status, bool isFragile)
        {
            ClientId = clientId;
            Address1 = address1;
            Address2 = address2;
            Distance = distance;
            Status = status;
            IsFragile = isFragile;
            CreateDate = DateTime.UtcNow;
        }

    }
}
