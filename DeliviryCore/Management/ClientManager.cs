using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliviryCore.Management
{
    class ClientManager 
    {
        public Dictionary<int, Client> clients;


        public Client AddClient (string name, string address, string number) // метод добавления клиента
        {
            Client newCL = new Client(name, address, number); // создание нового клиента
            clients.Add(newCL.ID, newCL); // добавление id клиента
            return newCL;
        }

        public void RemoveClient(int ID) // метод удаления клиента
        {
            if (clients.ContainsKey(ID))
                clients.Remove(ID);
        }

        //метод редактирования

    }
}
