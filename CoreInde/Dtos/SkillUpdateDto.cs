using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Dtos
{
    public class SkillUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public Skillset Skillset { get; set; }
        [Required]

        public DateTime DateOfSkillCreation { get; set; }
        [Required]

        public string Description { get; set; }

        public SkillUpdateDto()
        {
            this.DateOfSkillCreation = DateTime.UtcNow;
        }

    }
}
