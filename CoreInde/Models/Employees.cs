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
        [Display(Name = "Skills")]
        public int SkillsId { get; set; }

        public Skills Skills { get; set; }

        public Employees()
        {
            this.HiringDate = DateTime.UtcNow;
        }
    }
}
