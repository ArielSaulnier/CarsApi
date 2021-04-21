using System.Collections.Generic;
using CarsApi.Models;

namespace CarsApi.Data
{
    public class MockCarRepo : ICarRepo
    {
        public void CreateCar(Car car)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCar(Car car)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            var cars = new List<Car>
            {
                new Car{Year=2012,Id=0,Horsepower=220,Price=52000,Make="Acura",Model="C300", ImgUrl="https://i.gaw.to/content/photos/38/75/387560_Acura.jpg"},
                new Car{Year=2012,Id=1,Horsepower=220,Price=52000,Make="Acura",Model="C400", ImgUrl="https://i.gaw.to/content/photos/38/75/387560_Acura.jpg"},
            };
            return cars;
        }

        public Car GetCarById(int id)
        {
            return new Car{Year=2012,Id=0,Horsepower=220,Price=52000,Make="Acura",Model="C300", ImgUrl="https://i.gaw.to/content/photos/38/75/387560_Acura.jpg"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new System.NotImplementedException();
        }
    }
}