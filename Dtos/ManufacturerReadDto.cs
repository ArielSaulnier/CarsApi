using System.ComponentModel.DataAnnotations;

namespace CarsApi.Dtos
{
    public class ManufacturerReadDto
    {
        public int NumModels { get; set; }

        public int MaxCarId { get; set; }

        public int AvgHorsepower { get; set; }

        public int Id { get; set; }

        public int AvgPrice { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }
    }
}