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
    public class ScoutModel : Record
    {
        #region Entity Properties

        [DisplayName("Scout Name")]
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        public string Password { get; set; }

        #endregion

        #region Extra Properties
        [DisplayName("Report Count")]
        public int ReportCount { get; set; }

        [DisplayName("Contracted Clubs")]
        public string ClubNames { get; set; }

        #endregion
    }
}
