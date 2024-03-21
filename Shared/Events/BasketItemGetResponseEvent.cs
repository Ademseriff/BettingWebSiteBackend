using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class BasketItemGetResponseEvent
    {
        public string  Id { get; set; }

       public List<BasketGetResponseEventMessage> messages { get; set; }
    }
}
