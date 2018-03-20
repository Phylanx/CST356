using Final.UserEntities;
using Final.Web.Models;
using System;
using System.Collections.Generic;

namespace Final.Web.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Car GetCar(String id)
        {
            return _db.Cars.Find(id);
        }
        public IEnumerable<Car> GetUserCars(String userId)
        {
            var cars = new List<Car>();
            foreach(var car in _db.Cars)
            {
                if(car.OwnerId == userId) cars.Add(car);
            }
            return cars;
        }
        public void CreateCar(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }
        public void UpdateCar(Car car)
        {
            _db.SaveChanges();
        }
        public void DeleteCar(String id)
        {
            var car = _db.Cars.Find(id);
            if (car == null) return;
            _db.Cars.Remove(car);
            _db.SaveChanges();
        }
    }
}