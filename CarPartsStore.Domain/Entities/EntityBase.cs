﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool? Deleted { get; set; }
    }
}
