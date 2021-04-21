using System.ComponentModel.DataAnnotations;

namespace CarsApi.Dtos
{
    public class EngineReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Horsepower { get; set; }

        public int Cylinder { get; set; }

        public int Torque { get; set; }

        public string FuelType { get; set; }

    }
}