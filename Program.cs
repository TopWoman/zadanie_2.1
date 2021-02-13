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
            DeliveryManager deliveryManager = new DeliveryManager();
            OrderManager orderManager = new OrderManager();

            clientManager.AddClient("Artem", "cvgcffcdcfr", "876543");
            clientManager.AddClient("ADWAtem", "cvgcffcdcfr", "876543");
            clientManager.AddClient("ASEFGHJtem", "cvgcffcdcfr", "876543");

            deliveryManager.AddCourier("gfds", DeliveryStatus.Expectation, 15, 50);
            deliveryManager.AddCourier("gfds", DeliveryStatus.Expectation, 15, 50);
            deliveryManager.AddCourier("gfds", DeliveryStatus.Expectation, 15, 50);

            orderManager.AddOrder(clientManager.clients[1], "rew", "ytr", 12,  9, OrderStatus.Accepted, false);
            orderManager.assemblys[1].Products.Add(new Product("5432", 34, false, new Dimensions(1, 1, 1)));
            orderManager.assemblys[1].Products.Add(new Product("Dildo Dashy", 34, false, new Dimensions(1, 1, 1)));
            orderManager.AddOrder(clientManager.clients[2], "rtw", "ytr", 12,  9, OrderStatus.Accepted, false);
            orderManager.assemblys[2].Products.Add(new Product("5432", 34, false, new Dimensions(1, 1, 1)));
            orderManager.AddOrder(clientManager.clients[3], "ytrw", "ytr", 12, 9, OrderStatus.Accepted, false);
            orderManager.assemblys[3].Products.Add(new Product("5432", 34, false, new Dimensions(1, 1, 1)));


         
        
            Console.WriteLine("КЛИЕНТЫ \n");
            foreach (var item in clientManager.clients)
            {
                Console.WriteLine($"Имя - {item.Value.Name}, Адрес - {item.Value.Address}, Номер - {item.Value.Number} \n");
            }

            Console.WriteLine("КУРЬЕРЫ \n");
            foreach (var item in deliveryManager.couriers)
            {
                Console.WriteLine($"Имя - {item.Value.Name}, Статус - {item.Value.Status}, Скорость - {item.Value.Speed}, МаксДис - {item.Value.MaxDistance} \n\n");
            }
        

            Console.WriteLine("ЗАКАЗЫ \n");
            foreach (var item in orderManager.assemblys)
            {
                Console.WriteLine($" АЙДИ - {item.Value.ID },Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"НЕПОНЯТНОШТО - {item.Value.OrderCreationDate} ");
                foreach (var pr in item.Value.Products)
                {
                    Console.WriteLine($"\t {pr.Name}, {pr.Weight}");
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
                    $"НЕПОНЯТНОШТО - {item.Value.OrderCreationDate} ");
                foreach (var pr in item.Value.Products)
                {
                    Console.WriteLine($"\t {pr.Name}, {pr.Weight}");
                }
            }

            Console.WriteLine("ДОСТАВКА");
            foreach (var item in orderManager.deliverings)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"НЕПОНЯТНОШТО - {item.Value.OrderCreationDate} ");
                foreach (var pr in item.Value.Products)
                {
                    Console.WriteLine($"\t {pr.Name}, {pr.Weight}");
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
                    $"НЕПОНЯТНОШТО - {item.Value.OrderCreationDate} ");
                foreach (var pr in item.Value.Products)
                {
                    Console.WriteLine($"\t {pr.Name}, {pr.Weight}");
                }
            }

            Console.WriteLine("ДОСТАВКА");
            foreach (var item in orderManager.deliverings)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"НЕПОНЯТНОШТО - {item.Value.OrderCreationDate} ");
                foreach (var pr in item.Value.Products)
                {
                    Console.WriteLine($"\t {pr.Name}, {pr.Weight}");
                }
            }
            Console.WriteLine("ЗАВЕРШЕННЫЕ ЗАКАЗЫ");
            foreach (var item in orderManager.completeds)
            {
                Console.WriteLine($"Клиент - {item.Value.Client.Name}, Адрес1 - {item.Value.Address1}, " +
                    $"Адрес2 - {item.Value.Address2}, вес - {item.Value.Weight}, " +
                    $"Дист - {item.Value.Distance}, Статус - {item.Value.Status}, " +
                    $"ISF  - {item.Value.IsFragile} " +
                    $"НЕПОНЯТНОШТО - {item.Value.OrderCreationDate} ");
                foreach (var pr in item.Value.Products)
                {
                    Console.WriteLine($"\t {pr.Name}, {pr.Weight}");
                }
            }
        }
    }
}
