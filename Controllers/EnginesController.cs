using System.Collections.Generic;
using AutoMapper;
using CarsApi.Data;
using CarsApi.Dtos;
using CarsApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    
    //api/engines
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        private readonly IEngineRepo _repository;
        private readonly IMapper _mapper;

        public EnginesController(IEngineRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/engines
        [HttpGet]
        public ActionResult <IEnumerable<EngineReadDto>> GetAllEngines(){
            var engineItems = _repository.GetAllEngines();
            return Ok(_mapper.Map<IEnumerable<EngineReadDto>>(engineItems));
        }

        //GET api/engines/{id} (a number)
        [HttpGet("{id}",Name="GetEngineById")]
        public ActionResult <EngineReadDto> GetEngineById(int id)
        {
            var engineItem = _repository.GetEngineById(id);
             if(engineItem != null)
            {
                return Ok(_mapper.Map<EngineReadDto>(engineItem));
            }
            
            return NotFound();
        }

        //POST api/engines
        [HttpPost]
        public ActionResult<EngineReadDto> CreateCar(EngineCreateDto ecdto)
        {
            var engineModel = _mapper.Map<Engine>(ecdto);
            _repository.CreateEngine(engineModel);
            _repository.SaveChanges();

            var engineReadDto = _mapper.Map<EngineReadDto>(engineModel);

            return(CreatedAtRoute(nameof(GetEngineById),new {Id = engineReadDto.Id},engineReadDto));

            //return Ok(engineModel);
        }

        //PUT api/engines/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEngine(int id, EngineUpdateDto engineUpdateDto)
        {
            var engineModelFromRepo = _repository.GetEngineById(id);
            if(engineModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(engineUpdateDto,engineModelFromRepo);
            _repository.UpdateEngine(engineModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/engines/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialEngineUpdate(int id, JsonPatchDocument<EngineUpdateDto> patchDoc)
        {
            var engineModelFromRepo = _repository.GetEngineById(id);
            if(engineModelFromRepo == null)
            {
                return NotFound();
            }

            var engineToPatch = _mapper.Map<EngineUpdateDto>(engineModelFromRepo);
            patchDoc.ApplyTo(engineToPatch,ModelState);
            if(!TryValidateModel(engineToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(engineToPatch,engineModelFromRepo);
            _repository.UpdateEngine(engineModelFromRepo);
            _repository.SaveChanges();
             return NoContent();
        }

        //DELETE api/engines/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEngine(int id)
        {
            var engineModelFromRepo = _repository.GetEngineById(id);
            if(engineModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEngine(engineModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }

    
}