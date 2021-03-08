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
        public string Name { get; set; }

        public DateTime DateOfSkillCreation { get; set; }
        [Required]

        public string Description { get; set; }

        public SkillUpdateDto()
        {
            this.DateOfSkillCreation = DateTime.UtcNow;
        }

    }
}
