using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryCore.Data;

namespace DeliveryCore.Management
{
    class DeliveryManager
    {
        private readonly AppContext _dbContext;

        public List<Delivery> Deliveries => _dbContext.Deliveries.ToList();

        public DeliveryManager()
        {
            _dbContext = new AppContext();
        }

        public Delivery AddDelivery(List<Order> orders, DeliveryType deliveryType)
        {
            Delivery newDelivery = new Delivery(deliveryType);
            _dbContext.Deliveries.Add(newDelivery);
            _dbContext.SaveChanges();

            foreach (var order in orders)
            {
                _dbContext.DeliveryLines.Add(new DeliveryLine()
                {
                    DeliveryId = newDelivery.Id,
                    OrderId = order.Id
                });
            }

            _dbContext.SaveChanges();
            return newDelivery;
        }
    }
}
