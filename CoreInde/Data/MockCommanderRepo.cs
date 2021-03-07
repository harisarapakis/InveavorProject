using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Skills cmd)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(Employees cmd)
        {
            throw new NotImplementedException();
        }

        public void CreateSkill(Skills cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Skills cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employees cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteSkill(Skills cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skills> GetAllCommands()
        {
            var commands = new List<Skills>
            {
                new Skills{Id=0, Skill="Boil an egg",  Description="Kettle & Pan"},
                new Skills{Id=1, Skill="Cut bread",  Description="knife & chopping board"},
                new Skills{Id=2, Skill="Make cup of tea",  Description="Kettle & cup"}
            };

            return commands;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skills> GetAllSkill()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skills> GetAllSkills()
        {
            throw new NotImplementedException();
        }

        public Skills GetCommandById(int id)
        {
            return new Skills { Id = 0, Skill = "Boil an egg", Description = "Kettle & Pan" };
        }

        public Employees GetEmployeesById(int id)
        {
            throw new NotImplementedException();
        }

        public Skills GetSkillById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Skills cmd)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employees cmd)
        {
            throw new NotImplementedException();
        }

        public void UpdateSkill(Skills cmd)
        {
            throw new NotImplementedException();
        }
    }

}

