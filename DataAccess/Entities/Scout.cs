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
    public class Scout : Record
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }

        // Relationships 
        public List<ClubScout> ClubScouts { get; set; }

        public List<ScoutReport> ScoutReports { get; set; }

    }
}
