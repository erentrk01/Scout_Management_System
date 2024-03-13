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
    public class CoachModel : Record
    {
        #region Entity Properties
        [DisplayName("Coach Name")]
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string TacticalSystem { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string Formation { get; set; }

        public ExperienceLevel Experience { get; set; }


        [Required(ErrorMessage = "{0} is required!")]
        public int ClubId { get; set; }


        #endregion

        #region Extra Properties
        [DisplayName("Position Count")]
        public int PositionCount { get; set; }

        public string PositionNames { get; set; }

        public string ClubName { get; set; }


 
        #endregion
    }
}
