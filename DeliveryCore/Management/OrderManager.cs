using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DeliveryCore.Management
{
    //TODO ПЕРЕДЕЛАТЬ ЕГО НАХУЙ ПОЛНОСТЬЮ
    class OrderManager
    {
        public Dictionary<int, Order> assemblys; //сборка
        public Dictionary<int, Order> canceleds; //отменен
        public Dictionary<int, Order> deliverings; //доставляется
        public Dictionary<int, Order> completeds; //выполнен

        public OrderManager()
        {
            assemblys = new Dictionary<int, Order>();
            canceleds = new Dictionary<int, Order>();
            deliverings = new Dictionary<int, Order>();
            completeds = new Dictionary<int, Order>();
        }

        public Order AddOrder (Client client, string address1, string address2, double weight,
                    double distance, OrderStatus status, bool isfragile) // метод добавления заказа
        {
            Order newASS = new Order(client.Id, address1, address2, weight, distance, status, isfragile); // создание нового заказа
            assemblys.Add(newASS.Id, newASS); // добавление ID заказа
            return newASS;
        }



        public void CancelOrder(int ID) // метод отмены заказа
        {
            if (assemblys.ContainsKey(ID) && assemblys[ID].Status == OrderStatus.Assemblys) 
            { 
                //проверить работоспособность (как сохранится в canseled)
                canceleds.Add(ID, assemblys[ID]);
                assemblys.Remove(ID);
            }

            if (deliverings.ContainsKey(ID) && deliverings[ID].Status == OrderStatus.Delivering)
            {
                canceleds.Add(ID, deliverings[ID]);
                deliverings.Remove(ID);
            }
        }

        public void CompleteOrder(int ID)
        {
            if (deliverings.ContainsKey(ID))
            {
                deliverings[ID].Status = OrderStatus.Completed;
                deliverings[ID].CompleteDate = DateTime.Now;
                completeds.Add(ID, deliverings[ID]);
                deliverings.Remove(ID);
            }

        }

        public void Deliver(int ID)
        {
            if (assemblys.ContainsKey(ID))
            {
                assemblys[ID].Status = OrderStatus.Delivering;
                deliverings.Add(ID, assemblys[ID]);
                assemblys.Remove(ID);
            }

        }



 
    }
}
