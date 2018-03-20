using Final.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Web.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(String id);
        IEnumerable<Car> GetUserCars(String userId);
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(String id);
    }
}