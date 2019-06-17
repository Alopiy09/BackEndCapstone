using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Alignment { get; set; } 
        [Required]
        [Range(1,20)]
        public int Strength { get; set; }

        [Required]
        [Range(1, 20)]
        public int Dexterity { get; set; }

        [Required]
        [Range(1, 20)]
        public int Constitution { get; set; }

        [Required]
        [Range(1, 20)]
        public int Intelligence { get; set; }

        [Required]
        [Range(1, 20)]
        public int Wisdom { get; set; }

        [Required]
        [Range(1, 20)]
        public int Charisma { get; set; }

        
        public string UserId { get; set; }

       
        public ApplicationUser User { get; set; }

     
        [Display(Name = "Class")]
        public int CharacterClassId { get; set; }

        public CharacterClass characterClasses { get; set; }

      
        [Display(Name = "Background")]
        public int BackgroundId { get; set; }

        
        public Background background { get; set; }

       
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }

      
        public ICollection<Equipment> equipment { get; set; }

        
        [Display(Name = "Feat")]
        public int FeatId { get; set; }

      
        public ICollection<Feat> feats { get; set; }

   
        [Display(Name = "Race")]
        public int RaceId { get; set; }

      
        public Race Race { get; set; }

        
    }
}
