using System;
using DeliveryCore.Data;
using DeliveryCore.Management;

namespace DeliveryCore
{
    class Program
    {
        static void Main(string[] args)
        {



            ClientManager clientManager = new ClientManager();
            DeliverierManager deliveryManager = new DeliverierManager();
            OrderManager orderManager = new OrderManager();

            
            Client Artem = clientManager.AddClient("Artem", "cvgcffcdcfr", "876543");
            clientManager.AddClient("ADWAtem", "cvgcffcdcfr", "876543");
            clientManager.AddClient("ASEFGHJtem", "cvgcffcdcfr", "876543");

            deliveryManager.AddCourier("gfds", DeliveryStatus.Expectation, 15, 50);
            deliveryManager.AddCourier("gfds", DeliveryStatus.Expectation, 15, 50);
            deliveryManager.AddCourier("gfds", DeliveryStatus.Expectation, 15, 50);

            Order order1 = orderManager.AddOrder(Artem, "[f[f[f[", "[f[[f[ff[", 12, 30, OrderStatus.Accepted, true);

            ProductManager productManager = new ProductManager();
            //Product Tort = productManager.AddProduct("tort", 1, true, new Dimensions(12, 13, 14));
            //order1.AddOrderLine(Tort, 5);


            

        
            Console.WriteLine("КЛИЕНТЫ \n");
            foreach (var item in clientManager.Сlients)
            {
                //Console.WriteLine($"Имя - {item.Value.Name}, Адрес - {item.Value.Address}, Номер - {item.Value.Number} \n");
            }

            Console.WriteLine("КУРЬЕРЫ \n");
            //foreach (var item in deliveryManager.couriers)
            //{
            //    Console.WriteLine($"Имя - {item.Value.Name}, Статус - {item.Value.Status}, Скорость - {item.Value.Speed}, МаксДис - {item.Value.MaxDistance} \n\n");
            //}
        

            Console.WriteLine("ЗАКАЗЫ \n");
            foreach (var item in orderManager.assemblys)
            {
                Console.WriteLine($" АЙДИ - {item.Value.Id },Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"НЕПОНЯТНОШТО - {item.Value.CreateDate} ");
                foreach (var pr in item.Value.OrderLines)
                {
                    Console.WriteLine($"\t {pr.Product.Name}, {pr.Product.Weight}, {pr.Count}");
                }
            } 

            OrderManager orderManager1 = new OrderManager();

           
             orderManager.Deliver(1);

            Console.WriteLine("СБОРКА");
            foreach (var item in orderManager.assemblys)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"ПОНЯТНОШТОДАТА - {item.Value.CreateDate} ");
                foreach (var pr in item.Value.OrderLines)
                {
                    Console.WriteLine($"\t {pr.Product.Name}, {pr.Product.Weight}, {pr.Count}");
                }
            }

            Console.WriteLine("ДОСТАВКА");
            foreach (var item in orderManager.deliverings)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"ПОНЯТНОШТОДАТА - {item.Value.CreateDate} ");
                foreach (var pr in item.Value.OrderLines)
                {
                    Console.WriteLine($"\t {pr.Product.Name}, {pr.Product.Weight}, {pr.Count}");
                }
            }

            orderManager.CompletedOrder(1);

            Console.WriteLine("СБОРКА");
            foreach (var item in orderManager.assemblys)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"ПОНЯТНОШТО - {item.Value.CreateDate} ");
                foreach (var pr in item.Value.OrderLines)
                {
                    Console.WriteLine($"\t {pr.Product.Name}, {pr.Product.Weight}, {pr.Count}");
                }
            }

            Console.WriteLine("ДОСТАВКА");
            foreach (var item in orderManager.deliverings)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"ПОНЯТНОШТОДАША - {item.Value.CreateDate} ");
                foreach (var pr in item.Value.OrderLines)
                {
                    Console.WriteLine($"\t {pr.Product.Name}, {pr.Product.Weight}, {pr.Count}");
                }
            }
            Console.WriteLine("ЗАВЕРШЕННЫЕ ЗАКАЗЫ");
            foreach (var item in orderManager.completeds)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"ПОНЯТНОШТО - {item.Value.CreateDate} ");
                foreach (var pr in item.Value.OrderLines)
                {
                    Console.WriteLine($"\t {pr.Product.Name}, {pr.Product.Weight}, {pr.Count}");
                }


            }
        }
    }
}
