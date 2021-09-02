using System.ComponentModel.DataAnnotations;

namespace CarsApi.Dtos
{
    public class EngineCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public int Cylinder { get; set; }

        [Required]
        public int Torque { get; set; }

        [Required]
        public string FuelType { get; set; }

    }
}