using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryCore.Data
{
    public class CanceledOrder : IOrder<CanceledOrderLine>
    {
        public int Id { get; set; }

        public Client Client { get; }

        public int ClientId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CancelDate { get; set; }
        public double Weight { get; set; }

        public List<CanceledOrderLine> OrderLines
        {
            get
            {
                using AppContext dbContext = new AppContext();
                return dbContext.CanceledOrderLines.Where(ordLine => ordLine.OrderId == Id).ToList();
            }

        }

        public double Volume { get; set; }

        public double Distance { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsFragile { get; set; }

        public void RemoveOrderLine(CompletedOrderLine orderLine)
        {
            if (orderLine == null)
                throw new ArgumentNullException(nameof(orderLine));
            using AppContext dbContext = new AppContext();
            CanceledOrderLine lineToDelete = dbContext.CanceledOrderLines.Find(orderLine.Id);
            if (lineToDelete == null)
                throw new ArgumentException($"No order line with id = {orderLine.Id}");
            dbContext.CanceledOrderLines.Remove(lineToDelete);
            dbContext.SaveChanges();
        }

        public void RemoveOrderLine(CanceledOrderLine orderLine)
        {
            using AppContext dbContext = new AppContext();
            if (orderLine == null)
                throw new ArgumentNullException(nameof(orderLine));
            dbContext.Attach(orderLine);
            dbContext.CanceledOrderLines.Remove(orderLine);
            dbContext.SaveChanges();
        }

        public void RemoveOrderLine(int id)
        {
            using AppContext dbContext = new AppContext();
            CanceledOrderLine lineToDelete = dbContext.CanceledOrderLines.Find(id);
            if (lineToDelete == null)
                throw new ArgumentException($"No order line with id = {id}");
            dbContext.CanceledOrderLines.Remove(lineToDelete);
            dbContext.SaveChanges();
        }
    }
}