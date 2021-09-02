using System;
using System.Collections.Generic;
using System.Linq;
using CarsApi.Models;

namespace CarsApi.Data
{
    class SqlEngineRepo : IEngineRepo

    {
        private CarContext _ctx;

        public SqlEngineRepo(CarContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateEngine(Engine engine)
        {
           if(engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            _ctx.Engines.Add(engine);
        }

        public void DeleteEngine(Engine engine)
        {
            if(engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            _ctx.Engines.Remove(engine);
        }

        public IEnumerable<Engine> GetAllEngines()
        {
            return _ctx.Engines.ToList();
        }

        public Engine GetEngineById(int id)
        {
            return _ctx.Engines.FirstOrDefault(predicate=>predicate.Id == id);
        }

        public bool SaveChanges()
        {
           return(_ctx.SaveChanges()>=0);
        }

        public void UpdateEngine(Engine engine)
        {
            //Nothing
        }
    }
}