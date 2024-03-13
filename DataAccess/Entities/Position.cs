using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class Position : Record
    {
        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public ExperienceLevel Experience { get; set; }

        public string SpecialSkill {  get; set; }
        public string MainPositioning { get; set; }
        public string SecondaryPositioning { get; set; }
        public string Description { get; set; }
        public string TechnicalProficiency { get; set; }

        public string Personality;
        
        public string DribblingAbility { get; set; }

        public string PressingAbility { get; set; }

        public int CoachId;
        public Coach Coach { get; set; }

    }
}
