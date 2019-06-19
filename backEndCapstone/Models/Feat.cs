using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class Feat
    {
        [Key]
        public int FeatId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Description { get; set; }
        [Display(Name = "Ability")]
        public string featAbility { get; set; }
    }
}
