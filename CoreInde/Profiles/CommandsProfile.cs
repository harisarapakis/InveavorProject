using AutoMapper;
using CoreInde.Dtos;
using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Skills, SkillReadDto>();
            CreateMap<SkillCreateDto, Skills>();
            CreateMap<SkillUpdateDto, Skills>();
            CreateMap<Skills, SkillUpdateDto>();


            CreateMap<Employees, EmployeesReadDto>();
            CreateMap<EmployeesCreateDto, Employees>();
            CreateMap<EmployeesUpdateDto, Employees>();
            CreateMap<Employees, EmployeesUpdateDto>();

        }
    }
}
