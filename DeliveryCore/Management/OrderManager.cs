using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DeliveryCore.Management
{
    class OrderManager
    {
        private readonly AppContext _dbContext;
        public List<Order> Orders => _dbContext.Orders.ToList();
        public List<CompletedOrder> CompletedOrders => _dbContext.CompletedOrders.ToList();
        public List<CanceledOrder> CanceledOrders => _dbContext.CanceledOrders.ToList();

        public OrderManager()
        {
            _dbContext = new AppContext();
        }

        public Order AddOrder(Client client, List<OrderLine> orderLines, string address1, 
            string address2, double distance, bool isFragile) // метод добавления заказа
        {
            Order newOrder = new Order(client.Id, address1, address2,
                distance, OrderStatus.Accepted, isFragile);
            _dbContext.Orders.Add(newOrder); // Добавление заказа
            _dbContext.SaveChanges();

            foreach (var ordLine in orderLines)
                ordLine.OrderId = newOrder.Id;

            // Добавление строк заказов.
            _dbContext.OrderLines.AddRange(orderLines);
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
                    CancelDate = DateTime.UtcNow,
                    Weight = ordToCancel.Weight,
                    Volume = ordToCancel.Volume,
                    Distance = ordToCancel.Distance,
                    Status = OrderStatus.Completed,
                    IsFragile = ordToCancel.IsFragile
                };
                _dbContext.CanceledOrders.Add(canceledOrder);
                _dbContext.SaveChanges();

                List<CanceledOrderLine> canceledOrderLines = new List<CanceledOrderLine>();
                foreach (var orderLine in ordToCancel.OrderLines)
                {
                    canceledOrderLines.Add(new CanceledOrderLine(orderLine.ProductId, orderLine.Count) { OrderId = canceledOrder.Id });
                }
                _dbContext.CanceledOrderLines.AddRange(canceledOrderLines);

                //Переливка строк заказа.
                foreach (var ordLine in ordToCancel.OrderLines)
                    ordToCancel.RemoveOrderLine(ordLine);
                _dbContext.Orders.Remove(ordToCancel);
                _dbContext.SaveChanges();
                return canceledOrder;
            }
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
                _dbContext.SaveChanges();
                // Перенос строк заказов завершённых заказов.
                List<CompletedOrderLine> completedOrderLines = new List<CompletedOrderLine>();
                foreach (var orderLine in ordToComplete.OrderLines)
                {
                    completedOrderLines.Add(new CompletedOrderLine(orderLine.ProductId, orderLine.Count) { OrderId = completedOrder.Id });
                }
                _dbContext.CompletedOrderLines.AddRange(completedOrderLines);

                //Переливка строк заказа.
                foreach (var ordLine in ordToComplete.OrderLines)
                    ordToComplete.RemoveOrderLine(ordLine);

                _dbContext.Orders.Remove(ordToComplete);
                _dbContext.SaveChanges();
                return completedOrder;
            }
            throw new ArgumentException($"No order with id ={id}");

        }
    }
}
