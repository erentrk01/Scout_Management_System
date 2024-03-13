﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Records.Bases
{
    public abstract class Record
    {
        public int Id { get; set; } // property, is required
        public string? Guid { get; set; } // property, is not required
    }
}
