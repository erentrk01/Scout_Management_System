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
    public class Report : Record
    {
        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        [Required]
        [StringLength(200)]
        public string VideoLink { get; set; }

        public string Weakness { get; set; }

        public string Strength { get; set; }
        public string AdditionalNote { get; set; }

        [Range(0, 100)]
        public int Point { get; set; } // Integer between 0 and 100

        [Required]
        [StringLength(1000)]
        public string FitExplanation { get; set; }

        public PotentialLevel Potential { get; set; }

        //Relationships
        // one to one 
        public ScoutReport ScoutReport { get; set; }

        public List<TargetListReport> TargetListReports { get; set; }

        // many to many 
        public List<PositionReport> PositionReports { get; set; }
    }

}

