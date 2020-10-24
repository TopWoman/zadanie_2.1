using DeliveryCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.DeliviryCore.Management
{
    class DeliveryManager
    {
        public Dictionary<int, Courier> couriers;
        public Dictionary<int, CourierDriver> courierdrivers;
        public Dictionary<int, Machine> machines;

        public Courier AddCourier(string name, DeliveryStatus status, int speed, int maxdistance)
        {
            Courier newCO = new Courier(name, status, speed, maxdistance); // создание нового курьера
            couriers.Add(newCO.ID, newCO); // добавление id курьера
            return newCO;
        }

        public void RemoveCourier(int ID) // метод удаления курьера
        {
            if (couriers.ContainsKey(ID))
                couriers.Remove(ID);
        }

        public CourierDriver AddCourierDriver(string name, DeliveryStatus status, int speed, int maxdistance, string driverlicense)
        {
            CourierDriver newCD = new CourierDriver(name, status, speed, maxdistance, driverlicense); // создание нового водителя
            courierdrivers.Add(newCD.ID, newCD); // добавление id водителя
            return newCD;
        }

        public void RemoveCourierDriver(int ID) // метод удаления водителя
        {
            if (courierdrivers.ContainsKey(ID))
                courierdrivers.Remove(ID);
        }

        public Machine AddMachine(string name, DeliveryStatus status, int speed, int maxdistance,
                        double volume, double carryingcapacity, string number)
        {
            Machine newMA = new Machine(name, status, speed, maxdistance, volume, carryingcapacity, number); // создание нового 
            machines.Add(newMA.ID, newMA); // добавление id 
            return newMA;
        }

        public void RemoveMachine(int ID) // метод удаления 
        {
            if (machines.ContainsKey(ID))
                machines.Remove(ID);
        }
    }
}
