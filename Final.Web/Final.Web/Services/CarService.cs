using Final.UserEntities;
using Final.Web.Models.Entities;
using Final.Web.Repositories;
using System;
using System.Collections.Generic;

namespace Final.Web.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        public CarService(ICarRepository rep)
        {
            _repository = rep;
        }

        public CarModel GetCar(String id)
        {
            return ToModel(_repository.GetCar(id));
        }
        public IEnumerable<CarModel> GetUserCars(String userId)
        {
            var cars = new List<CarModel>();
            foreach(var car in _repository.GetUserCars(userId))
            {
                cars.Add(ToModel(car));
            }
            return cars;
        }
        public void CreateCar(CarModel car)
        {
            _repository.CreateCar(ToCar(car));
        }
        public void UpdateCar(CarModel car)
        {
            var carRecord = _repository.GetCar(car.Id);
            carRecord.Make = car.Make;
            carRecord.Model = car.Model;
            carRecord.OwnerId = car.OwnerId;

            _repository.UpdateCar(carRecord);
        }
        public void DeleteCar(String id)
        {
            _repository.DeleteCar(id);
        }

        private CarModel ToModel(Car car)
        {
            return new CarModel
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                OwnerId = car.OwnerId
            };
        }
        private Car ToCar(CarModel car)
        {
            return new Car
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                OwnerId = car.OwnerId
            };
        }
    }
}