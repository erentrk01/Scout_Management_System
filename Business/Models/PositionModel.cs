using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Business.Models
{
    public class PositionModel : Record
    {
        #region Entity Properties
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public ExperienceLevel Experience { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string MainPositioning { get; set; }

        public string SecondaryPositioning { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string Description { get; set; }
        public string TechnicalProficiency { get; set; }


        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string Personality;

        public string DribblingAbility { get; set; }

        public string PressingAbility { get; set; }

        public string SpecialSkill { get; set; }

        public string CoachName { get; set; }

        #endregion

        #region Extra Properties
        [DisplayName("Report Count")]
        public int ReportCount { get; set; }
        #endregion
    }
}
