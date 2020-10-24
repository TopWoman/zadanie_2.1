using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DeliveryCore.DeliviryCore.Management
{
    class OrderManager
    { /// <summary>
    /// ДОДЕЛАТЬ - ПЕРЕДЕЛАААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААТЬ!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    /// АААААААААААААААААААААААААААААААААААААААААААААААААААА
    /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    /// </summary>
        public Dictionary<int, Order> assemblys; //сборка
        public Dictionary<int, Order> canceleds; //отменен
        public Dictionary<int, Order> deliverings; //доставляется
        public Dictionary<int, Order> completeds; //выполнен

        public Order AddOrder (Client client, string address1, string address2, double weight, Product product,
                    double distance, OrderStatus status, bool isfragile) // метод добавления заказа
        {
            Order newASS = new Order(client, address1, address2, weight, product, distance, status, isfragile); // создание нового заказа
            assemblys.Add(newASS.ID, newASS); // добавление id заказа
            return newASS;
        }

        public void CancelOrder(int ID) // метод удаления клиента
        {
            if (assemblys.ContainsKey(ID) && assemblys[ID].Status==OrderStatus.
                assemblys.Remove(ID);
        }
    }
}
