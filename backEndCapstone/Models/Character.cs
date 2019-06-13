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
        [Required]
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

        [Required]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Class")]
        public int CharacterClassId { get; set; }

        [Required]
        public ICollection<CharacterClass> characterClasses { get; set; }

        [Required]
        [Display(Name = "Background")]
        public int BackgroundId { get; set; }

        [Required]
        public Background background { get; set; }

        [Required]
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }

        [Required]
        public ICollection<Equipment> equipment { get; set; }

        [Required]
        [Display(Name = "Feat")]
        public int FeatId { get; set; }

        [Required]
        public ICollection<Feat> feats { get; set; }

        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        [Required]
        public Race Race { get; set; }

        [Required]
        public ICollection<Skills> Skill { get; set; }

    }
}
