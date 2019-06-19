using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class Background
    {
        [Key]
        public int BackgroundId { get; set; }

        [Required]
        [Display(Name = "Background Name")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Abilities")]
        public string backgroundAbilities { get; set; }
    }
}
