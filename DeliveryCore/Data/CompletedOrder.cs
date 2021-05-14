using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryCore.Data
{
    public class CompletedOrder : IOrder
    {
        public int Id { get; set; }
        public Client Client { get; }
        public int ClientId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CompleteDate { get; set; } //дата выполнения заказа
        public double Weight { get; set; }
        //TODO выборка строк из завершённых строк
        public List<CompletedOrderLine> CompletedOrderLines
        {
            get
            {
                using AppContext dbContext = new AppContext();
                return dbContext.CompletedOrderLines.Where(ordLine => ordLine.Id == Id).ToList();
            }
            
        }
        public double Volume { get; set; }
        public double Distance { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsFragile { get; set; }
    }
}