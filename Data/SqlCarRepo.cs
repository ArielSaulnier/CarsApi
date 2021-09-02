using System;
using System.Collections.Generic;
using System.Linq;
using CarsApi.Models;

namespace CarsApi.Data
{
    class SqlCarRepo : ICarRepo

    {
        private CarContext _ctx;

        public SqlCarRepo(CarContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _ctx.Cars.Add(car);
        }

        public void DeleteCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _ctx.Cars.Remove(car);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _ctx.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _ctx.Cars.FirstOrDefault(predicate=>predicate.Id == id);
        }

        public bool SaveChanges()
        {
            return(_ctx.SaveChanges()>=0);
        }

        public void UpdateCar(Car car)
        {
            //Nothing
        }
    }
}