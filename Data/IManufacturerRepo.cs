using System.Collections.Generic;
using CarsApi.Models;

namespace CarsApi.Data
{
    public interface IManufacturerRepo
    {
        bool SaveChanges();
        IEnumerable<Manufacturer> GetAllManufacturers();
        Manufacturer GetManufacturerById(int id);
        void CreateManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);

        void DeleteManufacturer(Manufacturer manufacturer);
    }
}