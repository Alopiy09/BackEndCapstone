using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models.ViewModels
{
    public class CreateCharacterViewModel
    {
        public Character Character { get; set; }

        public List<Race> Races { get; set; }
    }
}
