﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}
