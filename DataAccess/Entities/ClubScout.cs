using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class ClubScout : Record
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }

        public int ScoutId { get; set; }
        public Scout Scout { get; set; }

    }
}
