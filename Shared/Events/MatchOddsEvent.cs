using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class MatchOddsEvent
    {
        public Guid MatchOddsAllId { get; set; }

        public IList<MatchOddsEventMessage> MatchOddsEvents { get; set;}
    }
}
