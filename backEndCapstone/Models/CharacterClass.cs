using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class CharacterClass
    {
        [Key]
        public int CharacterClassId { get; set; }

        [Required]
        [Display(Name = "Class")]
        public string ClassName { get; set; }

        [Required]
        [Display(Name = "Class Description")]
        public string ClassDescription { get; set; }

        [Required]
        [Display(Name = "Class Features")]
        public string ClassFeatures { get; set; }

        public int Experience { get; set; }

        [Display(Name = "Sub Class")]
        public int SubClassId { get; set; }
        public SubClass SubClass { get; set; }


    }
}
