using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Management
{
    class ClientManager 
    {
        public Dictionary<int, Client> clients;

        public ClientManager() 
        {
            clients = new Dictionary<int, Client>();
        }

        public Client AddClient (string name, string address, string number) // метод добавления клиента
        {
            Client newCL = new Client(name, address, number); // создание нового клиента
            clients.Add(newCL.ID, newCL); // добавление ID клиента
            return newCL;
        }

        public void RemoveClient(int ID) // метод удаления клиента
        {
            if (clients.ContainsKey(ID))
                clients.Remove(ID);
        }

        //метод редактирования
        public void EditClient (int ID, string name="", string address="", string number="")
        {
            if (name != "")
                clients[ID].Name = name;
            if (address != "")
                clients[ID].Address = address;
            if (number != "")
                clients[ID].Number = number;

        }

    }
}
