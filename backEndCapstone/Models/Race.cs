using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class Race
    {
        [Key]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        [Required]
        [Display(Name = "Race")]
        public string RaceType { get; set; }

        [Required]
        [Display(Name = "Racial Abilities")]
        public string RacialAbilities { get; set; }

        [Required]
        public int Speed { get; set; }
    }
}
