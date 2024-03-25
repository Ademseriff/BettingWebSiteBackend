using Shared.Enums;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderComplatedEvent
    {
        
     
       
        public string PaidMoney { get; set; }
    
        public string TotalMoney { get; set; }
     
        public string TotalRate { get; set; }

        public StateEnum state { get; set; }

        public List<OrderComplatedEventMessage> contentLists { get; set; }
    }
}
