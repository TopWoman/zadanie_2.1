using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryCore.Management
{
    class ClientManager
    {
        /// <summary>
        /// Получения списка клиентов из базы данных.
        /// </summary>
        public List<Client> Сlients
        {
            get
            {
                using AppContext dbContext = new AppContext();
                return dbContext.Clients.ToList();
            }
        }

        public ClientManager()
        {
        }


        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="number"></param>
        /// <returns>Созданный клиент</returns>
        public Client AddClient(string name, string address, string number) // метод добавления клиента
        {
            Client newCL = new Client(name, address, number); // создание нового клиента
            using AppContext dbContext = new AppContext();
            dbContext.Clients.Add(newCL);
            dbContext.SaveChanges();
            return newCL;
        }


        /// <summary>
        /// Удаление клиента по Id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveClient(int id) // метод удаления клиента
        {
            using AppContext dbContext = new AppContext();
            Client clientForDeleting = dbContext.Clients.Find(id);
            if (clientForDeleting == null)
                throw new ArgumentException($"There is no client with id = {id}");
            dbContext.Clients.Remove(clientForDeleting);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Изменение данных клиента.
        /// </summary>
        /// <param name="id">Id клиента для редактирования</param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="number"></param>
        public void EditClient(int id, string name = null, string address = null, string number = null)
        {
            using AppContext dbContext = new AppContext();
            Client client = dbContext.Clients.Find(id);
            if (client == null)
                throw new ArgumentException($"There is no client with id = {id}");
            client.Name ??= name;
            client.Address ??= address;
            client.Number ??= number;
        }

    }
}
