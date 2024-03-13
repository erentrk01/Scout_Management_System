using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class PositionReport : Record
    {
        public int PositonId { get; set; }
        public Position position { get; set; }

        public int ReportId { get; set; }
        public Report report { get; set; }


    }
}
