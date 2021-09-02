using System.Collections.Generic;
using CarsApi.Models;

namespace CarsApi.Data
{
    public class MockEngineRepo : IEngineRepo
    {
        public void CreateEngine(Engine engine)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEngine(Engine engine)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Engine> GetAllEngines()
        {
            var engines = new List<Engine>
            {
                new Engine{Id=0,Name="Erb",Horsepower=295,Cylinder=6,Torque=262,FuelType="flex-fuel (unleaded/E85)"},
                new Engine{Id=1,Name="Erb2",Horsepower=295,Cylinder=6,Torque=262,FuelType="flex-fuel (unleaded/E85)"},
            };
            return engines;
        }

        public Engine GetEngineById(int id)
        {
           return new Engine{Id=0,Name="Erb",Horsepower=220,Cylinder=6,Torque=262,FuelType="flex-fuel (unleaded/E85)"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Engine engine)
        {
            throw new System.NotImplementedException();
        }
    }
}