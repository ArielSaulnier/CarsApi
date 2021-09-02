using System.Collections.Generic;
using CarsApi.Models;

namespace CarsApi.Data
{
    public class MockManufacturerRepo : IManufacturerRepo
    {
        public void CreateManufacturer(Manufacturer manufacturer)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer{Id=0,NumModels=3,MaxCarId=104,AvgHorsepower=291,AvgPrice=32972,Name="chrysler",ImgUrl="http://www.carlogos.org/uploads/car-logos/Chrysler-logo-1.jpg"},
                new Manufacturer{Id=2,NumModels=3,MaxCarId=104,AvgHorsepower=291,AvgPrice=32972,Name="chrysler2",ImgUrl="http://www.carlogos.org/uploads/car-logos/Chrysler-logo-1.jpg"},
            };
            return manufacturers;
        }

        public Manufacturer GetManufacturerById(int id)
        {
            return new Manufacturer{Id=0,NumModels=3,MaxCarId=104,AvgHorsepower=291,AvgPrice=32972,Name="chrysler",ImgUrl="http://www.carlogos.org/uploads/car-logos/Chrysler-logo-1.jpg"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            throw new System.NotImplementedException();
        }
    }
}