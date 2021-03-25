using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryCore.Data;

namespace DeliveryCore.Management
{
    class DeliveryManager
    {
        private readonly AppContext _dbContext;

        public List<CourierDriver> CourierDrivers => _dbContext.CourierDrivers.ToList();
        public List<Courier> Couriers => _dbContext.Couriers.ToList();
        public List<Machine> Machines => _dbContext.Machines.ToList();


        public DeliveryManager()
        {
            _dbContext = new AppContext();
        }


        public Courier AddCourier(string name, DeliveryStatus status, int speed, int maxDistance)
        {
            Courier newCO = new Courier(name, status, speed, maxDistance); // создание нового курьера

            _dbContext.Couriers.Add(newCO);
            _dbContext.SaveChanges();
            return newCO;
        }

        public void RemoveCourier(int id) // метод удаления курьера
        {
            Courier courierForDeleting = _dbContext.Couriers.Find(id);
            if (courierForDeleting == null)
                throw new ArgumentException($"There is no client with id = {id}");
            _dbContext.Couriers.Remove(courierForDeleting);
            _dbContext.SaveChanges();
        }

        public CourierDriver AddCourierDriver(string name, DeliveryStatus status, int speed, int maxDistance, string driverLicense)
        {
            CourierDriver newCD = new CourierDriver(name, status, speed, maxDistance, driverLicense); // создание нового водителя
            _dbContext.CourierDrivers.Add(newCD);
            _dbContext.SaveChanges();
            return newCD;
        }

        public void RemoveCourierDriver(int id) // метод удаления водителя
        {
            CourierDriver courierDriverForDeleting = _dbContext.CourierDrivers.Find(id);
            if (courierDriverForDeleting == null)
                throw new ArgumentException($"There is no client with id = {id}");
            _dbContext.CourierDrivers.Remove(courierDriverForDeleting);
            _dbContext.SaveChanges();
        }

        public Machine AddMachine(string name, DeliveryStatus status, int speed, int maxDistance,
                        double volume, double carryingCapacity, string number)
        {
            Machine newMA = new Machine(name, status, speed, maxDistance, volume, carryingCapacity, number); // создание нового 
            _dbContext.Machines.Add(newMA);
            _dbContext.SaveChanges();
            return newMA;
        }

        public void RemoveMachine(int id) // метод удаления 
        {
            using AppContext _dbContext = new AppContext();
            Machine machineForDeleting = _dbContext.Machines.Find(id);
            if (machineForDeleting == null)
                throw new ArgumentException($"There is no client with id = {id}");
            _dbContext.Machines.Remove(machineForDeleting);
            _dbContext.SaveChanges();
        }
    }
}
