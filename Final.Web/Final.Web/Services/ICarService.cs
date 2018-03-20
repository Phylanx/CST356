using Final.Web.Models.Entities;
using System;
using System.Collections.Generic;

namespace Final.Web.Services
{
    public interface ICarService
    {
        CarModel GetCar(String id);
        IEnumerable<CarModel> GetUserCars(String userId);
        void CreateCar(CarModel car);
        void UpdateCar(CarModel car);
        void DeleteCar(String id);
    }
}