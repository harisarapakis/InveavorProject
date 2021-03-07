using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreInde.Data;
using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreInde.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace CoreInde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsApiController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public SkillsApiController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SkillReadDto>> GetAllSkills()
        {
            var commandItems = _repository.GetAllSkills();

            return Ok(_mapper.Map<IEnumerable<SkillReadDto>>(commandItems));
        }

        //GET api/Skills/{id}
        [HttpGet("{id}", Name = "GetSkillById")]
        public ActionResult<SkillReadDto> GetSkillById(int id)
        {
            var commandItem = _repository.GetSkillById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<SkillReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/skill
        [HttpPost]
        public ActionResult<SkillReadDto> CreateSkill(SkillCreateDto skillCreateDto)
        {
            var skillModel = _mapper.Map<Skills>(skillCreateDto);
            _repository.CreateSkill(skillModel);
            _repository.SaveChanges();

            var skillReadDto = _mapper.Map<SkillReadDto>(skillModel);

            return CreatedAtRoute(nameof(GetSkillById), new { Id = skillReadDto.Id }, skillReadDto);
        }

        // PUT api/skills/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSkill(int id, SkillUpdateDto skillUpdateDto)
        {
            var skillModelFromRepo = _repository.GetSkillById(id);
            if (skillModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(skillUpdateDto, skillModelFromRepo);

            _repository.UpdateSkill(skillModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/skills/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialSkillUpdate(int id, JsonPatchDocument<SkillUpdateDto> patchDoc)
        {
            var skillModelFromRepo = _repository.GetSkillById(id);
            if (skillModelFromRepo == null)
            {
                return NotFound();
            }
            var skillToPatch = _mapper.Map<SkillUpdateDto>(skillModelFromRepo);

            patchDoc.ApplyTo(skillToPatch, ModelState);
            if (!TryValidateModel(skillToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(skillToPatch, skillModelFromRepo);

            _repository.UpdateSkill(skillModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //DELETE api/skills/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSkill(int id)
        {
            var skillModelFromRepo = _repository.GetSkillById(id);
            if (skillModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSkill(skillModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
