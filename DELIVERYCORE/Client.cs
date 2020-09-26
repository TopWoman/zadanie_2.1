using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP
{
    class Client 
    {
        private static int nextId;
        private readonly int id;
        public virtual int ID => id;
        public string Name { get; }
        public string Address { get; }
        public string Number { get; }

        public Client(string name, string address, string number) 
        {
            Name = name;
            Address = address;
            Number = number;
            id = Interlocked.Increment(ref nextId);
        }

    }
}
