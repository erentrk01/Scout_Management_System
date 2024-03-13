using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class TargetListReport : Record
    {
        public int TargetListId { get; set; }
        public TargetList TargetList { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }

    }
}
