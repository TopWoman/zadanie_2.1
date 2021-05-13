using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DeliveryCore.Management
{
    //TODO ПЕРЕДЕЛАТЬ ЕГО НАХУЙ ПОЛНОСТЬЮ
    class OrderManager
    {
        private readonly AppContext _dbContext;
        public List<Order> Orders => _dbContext.Orders.ToList();
        public List<CompletedOrder> CompletedOrders => _dbContext.CompletedOrders.ToList();

        public OrderManager()
        {
            _dbContext = new AppContext();
        }

        public Order AddOrder(Client client, string address1, string address2, double weight,
                    double distance, OrderStatus status, bool isFragile) // метод добавления заказа
        {
            Order newOrder = new Order(client.Id, address1, address2,
                weight, distance, status, isFragile);
            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();
            return newOrder;
        }



        public CanceledOrder CancelOrder(int id) // метод отмены заказа
        {
            Order ordToCancel = _dbContext.Orders.Find(id);
            if (ordToCancel != null)
            {
                CanceledOrder canceledOrder = new CanceledOrder()
                {
                    ClientId = ordToCancel.ClientId,
                    Address1 = ordToCancel.Address1,
                    Address2 = ordToCancel.Address2,
                    CreateDate = ordToCancel.CreateDate,
                    CanceleDate = DateTime.UtcNow,
                    Weight = ordToCancel.Weight,
                    Volume = ordToCancel.Volume,
                    Distance = ordToCancel.Distance,
                    Status = OrderStatus.Completed,
                    IsFragile = ordToCancel.IsFragile
                };
                _dbContext.CanceledOrders.Add(canceledOrder);
                _dbContext.Orders.Remove(ordToCancel);
                _dbContext.SaveChanges();
                return canceledOrder;
            }
            else
                throw new ArgumentException($"No order with id ={id}");
        }

        public CompletedOrder CompleteOrder(int id)
        {
            Order ordToComplete = _dbContext.Orders.Find(id);
            if (ordToComplete != null)
            {
                CompletedOrder completedOrder = new CompletedOrder()
                {
                    ClientId = ordToComplete.ClientId,
                    Address1 = ordToComplete.Address1,
                    Address2 = ordToComplete.Address2,
                    CreateDate = ordToComplete.CreateDate,
                    CompleteDate = DateTime.UtcNow,
                    Weight = ordToComplete.Weight,
                    Volume = ordToComplete.Volume,
                    Distance = ordToComplete.Distance,
                    Status = OrderStatus.Completed,
                    IsFragile = ordToComplete.IsFragile
                };
                _dbContext.CompletedOrders.Add(completedOrder);
                _dbContext.Orders.Remove(ordToComplete);
                _dbContext.SaveChanges();
                return completedOrder;
            }
            else
                throw new ArgumentException($"No order with id ={id}");

        }
    }
}
