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
            Courier courier = new Courier(name, status, speed, maxDistance); // создание нового курьера
            _dbContext.Couriers.Add(courier);
            _dbContext.SaveChanges();
            return courier;
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
            CourierDriver courierDriver = new CourierDriver(name, status, speed, maxDistance, driverLicense); // создание нового водителя
            _dbContext.CourierDrivers.Add(courierDriver);
            _dbContext.SaveChanges();
            return courierDriver;
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
            Machine machine = new Machine(name, status, speed, maxDistance, volume, carryingCapacity, number); // создание нового 
            _dbContext.Machines.Add(machine);
            _dbContext.SaveChanges();
            return machine;
        }

        public void RemoveMachine(int id) // метод удаления 
        {
            Machine machineForDeleting = _dbContext.Machines.Find(id);
            if (machineForDeleting == null)
                throw new ArgumentException($"There is no client with id = {id}");
            _dbContext.Machines.Remove(machineForDeleting);
            _dbContext.SaveChanges();
        }
    }
}
