using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class Club : Record
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }

        // Relationships
        // one to many with Coach
        public List<Coach> Coachs { get; set; }

        // one to many with SportifDirectors
        public List<SportifDirector> SportifDirectors{ get; set; }

        // many to many Club-Scout
        public List<ClubScout> ClubScouts { get; set; }
    }
}
