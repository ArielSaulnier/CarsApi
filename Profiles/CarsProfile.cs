using AutoMapper;
using CarsApi.Dtos;
using CarsApi.Models;

namespace CarsApi.Profiles
{
    class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car,CarReadDto>();
            CreateMap<CarCreateDto,Car>();
            CreateMap<CarUpdateDto,Car>();
            CreateMap<Car,CarUpdateDto>();
        }
    }
}