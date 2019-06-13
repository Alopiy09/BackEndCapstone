using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class Skills
    {
        [Key]
        public int SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        public int SkillModifier { get; set; }
        
        public bool isProficient { get; set; }
    }
}
