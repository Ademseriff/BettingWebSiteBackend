﻿using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    public class BasketGetResponseEventMessage
    {
        public string Tc { get; set; }
        public string Team1 { get; set; }

        public string Team2 { get; set; }

        public MatchSideEnum MatchSide { get; set; }

        public string Rate { get; set; }
    }
}
