using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class CouponComplatedEvent
    {
        public string Tc { get; set; }

        public string TotalRate { get; set; }

        public string TotalMoney { get; set; }
    }
}
