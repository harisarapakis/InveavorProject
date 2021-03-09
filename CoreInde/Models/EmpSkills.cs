using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Models
{
    public class EmpSkills
    {
        public DateTime EmpSkillDate { get; set; }

        public int Employee3Id { get; set; }
        public Employees Employees3 { get; set; }
        public int Skills3Id { get; set; }
        public Skills Skills3 { get; set; }
    }
}
