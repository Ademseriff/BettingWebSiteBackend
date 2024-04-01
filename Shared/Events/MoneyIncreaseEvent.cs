using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class MoneyIncreaseEvent
    {
        public string Tc { get; set; }
        public string Money { get; set; }

        public MoneyTransactionEnum WhiceSide { get; set; }
    }
}
