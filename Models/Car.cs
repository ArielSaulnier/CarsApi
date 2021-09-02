using System.ComponentModel.DataAnnotations;

namespace CarsApi.Models
{
    public class Car
    {
        [Required]
        public int Year { get; set; }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public double Price { get; set;}

        [Required]
        public string Make { get; set;}

        [Required]
        public string Model { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}