using System.Collections.Generic;
using AutoMapper;
using CarsApi.Data;
using CarsApi.Dtos;
using CarsApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    //api/manufacturers
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerRepo _repository;
        private readonly IMapper _mapper;

        public ManufacturersController(IManufacturerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/manufacturers
        [HttpGet]
        public ActionResult <IEnumerable<ManufacturerReadDto>> GetAllMAnufacturers(){
            var manufacturerItems = _repository.GetAllManufacturers();
            return Ok(_mapper.Map<IEnumerable<ManufacturerReadDto>>(manufacturerItems));
        }

        //GET api/manufaturers/{id} (a number)
        [HttpGet("{id}",Name="GetManufacturerById")]
        public ActionResult <ManufacturerReadDto> GetManufacturerById(int id)
        {
            var manufacturerItem = _repository.GetManufacturerById(id);
             if(manufacturerItem != null)
            {
                return Ok(_mapper.Map<ManufacturerReadDto>(manufacturerItem));
            }
            
            return NotFound();
        }

        //POST api/manufacturers
        [HttpPost]
        public ActionResult<ManufacturerReadDto> CreateCar(ManufacturerCreateDto mcdto)
        {
            var manufacturerModel = _mapper.Map<Manufacturer>(mcdto);
            _repository.CreateManufacturer(manufacturerModel);
            _repository.SaveChanges();

            var manufacturerReadDto = _mapper.Map<ManufacturerReadDto>(manufacturerModel);

            return(CreatedAtRoute(nameof(GetManufacturerById),new {Id = manufacturerReadDto.Id},manufacturerReadDto));

            //return Ok(manufacturerReadDto);
        }

        //PUT api/manufacturers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEngine(int id, ManufacturerUpdateDto manufacturerUpdateDto)
        {
            var manufacturerModelFromRepo = _repository.GetManufacturerById(id);
            if(manufacturerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(manufacturerUpdateDto,manufacturerModelFromRepo);
            _repository.UpdateManufacturer(manufacturerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/manufacturers/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialManufacturerUpdate(int id, JsonPatchDocument<ManufacturerUpdateDto> patchDoc)
        {
            var manufacturerModelFromRepo = _repository.GetManufacturerById(id);
            if(manufacturerModelFromRepo == null)
            {
                return NotFound();
            }

            var manufacturerToPatch = _mapper.Map<ManufacturerUpdateDto>(manufacturerModelFromRepo);
            patchDoc.ApplyTo(manufacturerToPatch, ModelState);
            if(!TryValidateModel(manufacturerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(manufacturerToPatch,manufacturerModelFromRepo);
            _repository.UpdateManufacturer(manufacturerModelFromRepo);
            _repository.SaveChanges();
             return NoContent();
        }

        //DELETE api/manufacturers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteManufacturer(int id)
        {
            var manufacturerModelFromRepo = _repository.GetManufacturerById(id);
            if(manufacturerModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteManufacturer(manufacturerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }

    
}