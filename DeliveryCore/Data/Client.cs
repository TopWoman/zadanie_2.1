using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    public class Client 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }

        public Client(string name, string address, string number) 
        {
            Name = name;
            Address = address;
            Number = number;
        }

    }
}
