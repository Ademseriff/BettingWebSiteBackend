using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderGetEventResponseEvent
    {
        public string OrderGetEventId { get; set; }

        public List<CoupunContentEventMessage> coupunContents { get; set; }
    }
}
