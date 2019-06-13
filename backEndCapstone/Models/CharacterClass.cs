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
        public string ClassName { get; set; }

        [Required]
        public string ClassDescription { get; set; }

        [Required]
        public string ClassFeatures { get; set; }

        public int Experience { get; set; }

        public int SubClassId { get; set; }
        public SubClass SubClass { get; set; }


    }
}
