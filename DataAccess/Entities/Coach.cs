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
    public class Coach : Record
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }

        public ExperienceLevel Experience {  get; set; }

        [Required]
        [StringLength(25)]
        public string TacticalSystem {  get; set; }

        [Required]
        [StringLength(20)]
        public string Formation { get; set; }

        // Relationships
        // One coach can work on only one club.

        public int ClubId { get; set; }
        public Club Club { get; set; }
        public List<Position> Positions { get; set; }
    }

}

