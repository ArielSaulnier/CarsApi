using System.Collections.Generic;
using CarsApi.Models;

namespace CarsApi.Data
{
    public interface IEngineRepo
    {
        bool SaveChanges();
        IEnumerable<Engine> GetAllEngines();
        Engine GetEngineById(int id);
        void CreateEngine(Engine engine);

        void UpdateEngine(Engine engine);

        void DeleteEngine(Engine engine);
    }
}