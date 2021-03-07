using AutoMapper;
using CoreInde.Data;
using CoreInde.Dtos;
using CoreInde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EmployeesApiController(ICommanderRepo repository, IMapper mapper, ApplicationDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeesReadDto>> GetAllEmployees()
        {
            var employeesItems = _repository.GetAllEmployees();

            return Ok(_mapper.Map<IEnumerable<EmployeesReadDto>>(employeesItems));
        }

        //GET api/EmployeesApi/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<SkillReadDto> GetEmployeeById(int id)
        {
            var employeesItem = _repository.GetEmployeesById(id);
            if (employeesItem != null)
            {
                return Ok(_mapper.Map<EmployeesReadDto>(employeesItem));
            }
            return NotFound();
        }

        //POST api/EmployeesApi
        [HttpPost]
        public ActionResult<EmployeesReadDto> CreateEmployee(EmployeesCreateDto employeesCreateDto)
        {
            var employeeModel = _mapper.Map<Employees>(employeesCreateDto);
            _repository.CreateEmployee(employeeModel);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeesReadDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
        }




        // PUT api/EmployeesApi/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeesUpdateDto employeesUpdateDto)
        {
            var employeeModelFromRepo = _repository.GetEmployeesById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(employeesUpdateDto, employeeModelFromRepo);

            _repository.UpdateEmployee(employeeModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/EmployeesApi/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<EmployeesUpdateDto> patchDoc)
        {
            var employeeModelFromRepo = _repository.GetEmployeesById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            var employeeToPatch = _mapper.Map<EmployeesUpdateDto>(employeeModelFromRepo);

            patchDoc.ApplyTo(employeeToPatch, ModelState);
            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeModelFromRepo);

            _repository.UpdateEmployee(employeeModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //DELETE api/EmployeesApi/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeModelFromRepo = _repository.GetEmployeesById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEmployee(employeeModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
