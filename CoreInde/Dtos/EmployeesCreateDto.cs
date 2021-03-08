using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Dtos
{
    public class EmployeesCreateDto
    {
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public DateTime HiringDate { get; set; }


        public EmployeesCreateDto()
        {
            this.HiringDate = DateTime.UtcNow;
        }

    }
    
}
