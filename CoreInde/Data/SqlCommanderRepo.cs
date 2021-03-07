using CoreInde.Data;
using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CoreInde.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlCommanderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateSkill(Skills cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Skills.Add(cmd);
        }

        public void CreateEmployee(Employees cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Employees.Add(cmd);
        }

        public void DeleteSkill(Skills cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Skills.Remove(cmd);
        }

        public void DeleteEmployee(Employees cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Employees.Remove(cmd);
        }

        public IEnumerable<Skills> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            var query = _context.Employees.Include(s => s.Skillset).ToList();
            return query;
        }

        public Skills GetSkillById(int id)
        {
            return _context.Skills.FirstOrDefault(p => p.Id == id);
        }

        public Employees GetEmployeesById(int id)
        {
            return _context.Employees.Include(s => s.Skillset).FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSkill(Skills cmd)
        {
            //Nothing
        }

        public void UpdateEmployee(Employees cmd)
        {
            //Nothing
        }
    }
}
