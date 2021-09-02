using AutoMapper;
using CarsApi.Dtos;
using CarsApi.Models;

namespace CarsApi.Profiles
{
    class EnginesProfile : Profile
    {
        public EnginesProfile()
        {
            CreateMap<Engine,EngineReadDto>();
            CreateMap<EngineCreateDto,Engine>();
            CreateMap<EngineUpdateDto,Engine>();
             CreateMap<Engine,EngineUpdateDto>();
        }
    }
}