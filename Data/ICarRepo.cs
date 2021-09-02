using System.Collections.Generic;
using CarsApi.Models;

namespace CarsApi.Data
{
    public interface ICarRepo
    {

        bool SaveChanges();
        
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void CreateCar(Car car);

        void UpdateCar(Car car);

        void DeleteCar(Car car);
    }
}