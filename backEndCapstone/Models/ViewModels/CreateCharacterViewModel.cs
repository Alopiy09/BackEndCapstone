using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models.ViewModels
{
    public class CreateCharacterViewModel
    {
        public Character Character { get; set; }
        public List<SelectListItem> Races { get; set; }
        public List<SelectListItem> Feats { get; set; }
        public List<SelectListItem> Backgrounds { get; set; }
        public List<SelectListItem> CharacterClass { get; set; }
    }
}
