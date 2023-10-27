﻿using Spotfy.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Core.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
