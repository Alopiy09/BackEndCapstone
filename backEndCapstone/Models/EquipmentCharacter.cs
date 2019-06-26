using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class EquipmentCharacter
    {
        public int EquipmentCharacterId { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
