using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class TargetList : Record
    {
        // Relationships
        public List<TargetListReport> TargetListReports { get; set; }
    }
}
