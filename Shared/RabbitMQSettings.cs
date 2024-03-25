using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RabbitMQSettings
    {
        public const string MatchOddsApi_matchoddsrequestEventQueue = "MatchOddsApi_matchoddsrequestEventQueue";
        
        public const string UserInterface_matchoddsresponseEventQueue = "UserInterface_matchoddsresponseEventQueue";

        public const string CustomerTransactionsApi_CustomeraddEventQueue = "consumeraddEventQueue";

        public const string CustomerTransactionsApi_CustomerCheckRequest = "CustomerTransactionsApi_CustomerCheckRequest";

        public const string UserInterface_CustomerCheckResponse = "UserInterface_CustomerCheckResponse";

        public const string BasketApi_ItemAddqueue = "BasketApi_ItemAddqueue";

        public const string BasketApi_BasketItemGetRepuestEvent = "BasketApi_BasketItemGetRepuestEvent";

        public const string UserInterface_BasketItemGetResponseEvent = "BasketApi_BasketItemGetRepuestEvent";

        public const string PlayedCouponsApi_ComplatedEventQueue = "PlayedCouponsApi_ComplatedEventQueue";
    }
}
