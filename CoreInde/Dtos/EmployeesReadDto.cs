using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Dtos
{
    public class EmployeesReadDto
    {
        public int Id { get; set; }
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public DateTime HiringDate { get; set; }
        public Skillset Skillset { get; set; }
        public byte SkillsetId { get; set; }


        public EmployeesReadDto()
        {
            this.HiringDate = DateTime.UtcNow;
        }
    }
}
