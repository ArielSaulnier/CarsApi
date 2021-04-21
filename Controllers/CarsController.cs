using System.Collections.Generic;
using AutoMapper;
using CarsApi.Data;
using CarsApi.Dtos;
using CarsApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    //api/cars
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepo _repository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/cars
        [HttpGet]
        public ActionResult <IEnumerable<CarReadDto>> GetAllCars(){
            var carItems = _repository.GetAllCars();
            return Ok(_mapper.Map<IEnumerable<CarReadDto>>(carItems));
        }

        //GET api/cars/{id} (a number)
        [HttpGet("{id}",Name="GetCarById")]
        public ActionResult <CarReadDto> GetCarById(int id)
        {
            var carItem = _repository.GetCarById(id);
            if(carItem != null)
            {
                return Ok(_mapper.Map<CarReadDto>(carItem));
            }
            
            return NotFound();
        }

        //POST api/cars
        [HttpPost]
        public ActionResult<CarReadDto> CreateCar(CarCreateDto ccdto)
        {
            var carModel = _mapper.Map<Car>(ccdto);
            _repository.CreateCar(carModel);
            _repository.SaveChanges();

            var carReadDto = _mapper.Map<CarReadDto>(carModel);

            return(CreatedAtRoute(nameof(GetCarById),new {Id = carReadDto.Id},carReadDto));
            //return Ok(carReadDto);
        }

        //PUT api/cars/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, CarUpdateDto carUpdateDto)
        {
            var carModelFromRepo = _repository.GetCarById(id);
            if(carModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(carUpdateDto,carModelFromRepo);
            _repository.UpdateCar(carModelFromRepo);
            _repository.SaveChanges();
            return NoContent();


        }

        //PATCH api/cars/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCarUpdate(int id, JsonPatchDocument<CarUpdateDto> patchDoc)
        {
            var carModelFromRepo = _repository.GetCarById(id);
            if(carModelFromRepo == null)
            {
                return NotFound();
            }

            var carToPatch = _mapper.Map<CarUpdateDto>(carModelFromRepo);
            patchDoc.ApplyTo(carToPatch,ModelState);
            if(!TryValidateModel(carToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(carToPatch,carModelFromRepo);
            _repository.UpdateCar(carModelFromRepo);
            _repository.SaveChanges();
             return NoContent();
        }

        //DELETE api/cars/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var carModelFromRepo = _repository.GetCarById(id);
            if(carModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCar(carModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }

    
}