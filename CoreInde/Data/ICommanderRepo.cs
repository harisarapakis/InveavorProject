using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Skills> GetAllSkills();
        Skills GetSkillById(int id);
        void CreateSkill(Skills cmd);
        void UpdateSkill(Skills cmd);
        void DeleteSkill(Skills cmd);



        IEnumerable<Employees> GetAllEmployees();

        Employees GetEmployeesById(int id);
        void CreateEmployee(Employees cmd);
        void UpdateEmployee(Employees cmd);
        void DeleteEmployee(Employees cmd);

    }
}
