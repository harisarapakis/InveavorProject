using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.ViewModels
{
    public class EmployeeSkillViewModel
    {
        public IEnumerable<Skillset> Skillsets { get; set; }
        public Employees Employees { get; set; }
    }
}
