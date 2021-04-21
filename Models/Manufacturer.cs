using System.ComponentModel.DataAnnotations;

namespace CarsApi.Models
{
    public class Manufacturer
    {
        [Required]
        public int NumModels { get; set; }

        [Required]
        public int MaxCarId { get; set; }

        [Required]
        public int AvgHorsepower { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public int AvgPrice { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}