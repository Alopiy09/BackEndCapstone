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
        public int RaceId { get; set; }

        [Required]
        public int CharacterId { get; set; }

        [Required]
        public string RaceType { get; set; }

        [Required]
        public string RacialAbilities { get; set; }

        [Required]
        public int Speed { get; set; }
    }
}
