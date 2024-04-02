using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class CouponFailedEvent
    {
        public string Tc { get; set; }

        public string TotalRate { get; set; }

        public string TotalMoney { get; set; }
    }
}
