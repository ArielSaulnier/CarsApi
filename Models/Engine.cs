using System.ComponentModel.DataAnnotations;

namespace CarsApi.Models
{
    public class Engine
    {
        [Key]
        public int Id { get; set; }

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