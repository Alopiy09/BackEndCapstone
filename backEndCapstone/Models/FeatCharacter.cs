using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class FeatCharacter
    {
        public int FeatCharacterId { get; set; }
        public int FeatId { get; set; }
        public Feat Feat { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
