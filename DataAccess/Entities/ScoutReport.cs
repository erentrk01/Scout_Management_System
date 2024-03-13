using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class ScoutReport : Record
    {
        public int ScoutId { get; set; }
        public Scout Scout { get; set; }
        public int ReportId { get; set; }

        public Report Report { get; set; }

    }
}
