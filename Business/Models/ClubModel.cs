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
    public class ClubModel : Record
    {
        #region Entity Properties
        [DisplayName("Club Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }


        #endregion

        #region Extra Properties
        [DisplayName("Scout Count")]
        public int ScoutCount { get; set; }

		[DisplayName("Coach Names")]
		public string CoachNames { get; set; }

        #endregion
    }
}
