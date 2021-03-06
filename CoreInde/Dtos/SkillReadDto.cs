using CoreInde.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInde.Dtos
{
    public class SkillReadDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]

        public DateTime DateOfSkillCreation { get; set; }
        [Required]

        public string Description { get; set; }

        public SkillReadDto()
        {
            this.DateOfSkillCreation = DateTime.UtcNow;
        }
    }
}
