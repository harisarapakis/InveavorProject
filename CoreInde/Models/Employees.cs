using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Models
{
    public class Employees
    {
        
        public int Id { get; set; }
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public DateTime HiringDate { get; set; }
     
        public ICollection<Skills> Skills { get; set; }

        public List<EmpSkills> EmpSkills { get; set; }


        public Employees()
        {
            this.HiringDate = DateTime.UtcNow;
        }
    }
}
