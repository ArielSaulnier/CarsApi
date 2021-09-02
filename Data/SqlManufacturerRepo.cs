using System;
using System.Collections.Generic;
using System.Linq;
using CarsApi.Models;

namespace CarsApi.Data
{
    class SqlManufacturerRepo : IManufacturerRepo

    {
        private CarContext _ctx;

        public SqlManufacturerRepo(CarContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateManufacturer(Manufacturer manufacturer)
        {
            if(manufacturer == null)
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }

            _ctx.Manufacturers.Add(manufacturer);
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            if(manufacturer == null)
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }

            _ctx.Manufacturers.Remove(manufacturer);
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return _ctx.Manufacturers.ToList();
        }

        public Manufacturer GetManufacturerById(int id)
        {
            return _ctx.Manufacturers.FirstOrDefault(predicate=>predicate.Id == id);
        }

        public bool SaveChanges()
        {
            return(_ctx.SaveChanges()>=0);
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            //Nothing
        }
    }
}