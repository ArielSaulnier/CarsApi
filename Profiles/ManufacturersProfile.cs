using AutoMapper;
using CarsApi.Dtos;
using CarsApi.Models;

namespace CarsApi.Profiles
{
    class ManufacturersProfile : Profile
    {
        public ManufacturersProfile()
        {
            CreateMap<Manufacturer,ManufacturerReadDto>();
            CreateMap<ManufacturerCreateDto,Manufacturer>();
            CreateMap<ManufacturerUpdateDto,Manufacturer>();
            CreateMap<Manufacturer,ManufacturerUpdateDto>();
        }
    }
}