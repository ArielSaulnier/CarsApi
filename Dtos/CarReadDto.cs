using System.ComponentModel.DataAnnotations;

namespace CarsApi.Dtos
{
    public class CarReadDto
    {
        
        public int Year { get; set; }
        
        public int Id { get; set; }
      
        public int Horsepower { get; set; }

        public double Price { get; set;}

        public string Make { get; set;}

        public string Model { get; set; }

        public string ImgUrl { get; set; }
    }
}