using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    public class CoupunContentEventMessage
    {

        public string PaidMoney { get; set; }

        public string TotalMoney { get; set; }

        public string TotalRate { get; set; }

        public StateEnum state { get; set; }

        public List<OrderContentContentEventMessage> orderContentContents { get; set; }
    }
}
