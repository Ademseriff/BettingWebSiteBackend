﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class UserLoginCheckEvent
    {
        public string Tc { get; set; }

        public string Password { get; set; }

        public string TotalPrice { get; set; }
    }
}
