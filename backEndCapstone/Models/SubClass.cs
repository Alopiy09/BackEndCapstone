using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class SubClass
    {
        [Key]
        public int SubClassId { get; set; }

        public int SubClassClassId { get; set; }

        [Required]
        public string SubClassName { get; set; }

        [Required]
        public string SubClassDescription { get; set; }

        [Required]
        public string SubClassFeatures { get; set; }

    }
}
