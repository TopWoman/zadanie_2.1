using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryCore.Management
{
    class ProductManager
    {
        private readonly AppContext _dbContext;
        public List<Product> Products => _dbContext.Products.ToList();

        public ProductManager()
        {
            _dbContext = new AppContext();
        }

        public void RemoveProduct(Product product) //удаление продукта
        {
            if (Products.Contains(product))
                Products.Remove(product);
        }

        public Product AddProduct(string name, double weight, bool isFragile, double height,
            double width, double length, double price) //добавление продукта
        {
            Product newProd = new Product(name, weight, isFragile, height,
                 width, length, price);
            _dbContext.Products.Add(newProd);
            _dbContext.SaveChanges();
            return newProd;
        }
        public void ChangeProduct(int productId, double height,
            double width, double length, double weight, bool isFragile, double price, string name = "") //изменение продукта
        {
            Product prodToChange = _dbContext.Products.Find(productId);
            if (prodToChange == null) throw new ArgumentException($"No product with id = {productId}");
            
            if (name != "")
                prodToChange.Name = name;

            if (weight > 0)
                prodToChange.Weight = weight;

            if (prodToChange.IsFragile != isFragile)
                prodToChange.IsFragile = isFragile;
            if (price > 0)
                prodToChange.Price = price;
            _dbContext.SaveChanges();
        }
    }
}
