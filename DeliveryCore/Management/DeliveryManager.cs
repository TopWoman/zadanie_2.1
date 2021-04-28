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

        public Delivery AddDelivery()
        {
            return null;
        }
    }
}
