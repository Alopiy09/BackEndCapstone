﻿using System;
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
        public int CharacterId { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string backgroundAbilities { get; set; }
    }
}
