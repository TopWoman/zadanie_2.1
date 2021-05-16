using System;

namespace DeliveryCore.Data
{
    public class CompletedOrderLine : IOrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }

        public CompletedOrderLine(int productId, int count)
        {
            using AppContext dbContext = new AppContext();
            if (dbContext.Products.Find(ProductId) != null)
                ProductId = productId;
            else
                throw new ArgumentException($"No product with id = {productId}");
            Cost = Count * Product.Price;
        }
    }
}