using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryCore.Management
{
    class ProductManager
    {
        public List<Product> products;

        public ProductManager()
        {
            products = new List<Product> ();
        }

        public void RemoveProduct(Product product) //удаление продукта
        {
            if (products.Contains(product))
                products.Remove(product);
        }

        public Product AddProduct(string name, double weight, bool isfragile, Dimensions dimensions, double price) //добавление продукта
        {
            Product newProd = new Product(name, weight, isfragile, dimensions, price);
            products.Add(newProd);
            return newProd;
        }
        public void ChangeProduct(int product, Dimensions dimensions, double weight, bool isfragile, double price, string name = "") //изменение продукта
        {
            if (name != "")
                products[product].Name = name;

            if (weight > 0)
                products[product].Weight = weight;

            if (products[product].IsFragile != isfragile)
                products[product].IsFragile = isfragile;
            if (price > 0)
                products[product].Price = price;
        }
    }
}
