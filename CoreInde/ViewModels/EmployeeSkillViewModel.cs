using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.ViewModels
{
    public class EmployeeSkillViewModel
    {
        public DateTime EmpSkillDate { get; set; }

        public int Employee3Id { get; set; }
        public Employees Employees3 { get; set; }
        public int SkillsSetID { get; set; }
        public IEnumerable<Skills> SkillsSet { get; set; }
    }
}
