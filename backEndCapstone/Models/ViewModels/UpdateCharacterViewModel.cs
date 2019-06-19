using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models.ViewModels
{
    public class UpdateCharacterViewModel
    {
        public Character Character { get; set; }
        public List<SelectListItem> Feats { get; set; }
        public List<SelectListItem> Equipment { get; set; }
    }
}
