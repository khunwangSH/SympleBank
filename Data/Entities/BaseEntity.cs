﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data.Entities
{
    public class BaseEntity
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime LastUpdatedAt { get; set; }
        string LastUpdatedBy { get; set; }
    }
}
