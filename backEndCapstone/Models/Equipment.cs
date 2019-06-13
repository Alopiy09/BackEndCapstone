using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        public string EquipmentName { get; set; }

        [Required]
        public string EquipmentDescription { get; set; }

        [Required]
        public bool Atunded { get; set; }

    }
}
