﻿using System;
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

        public const string PlayedCouponsApi_GetCouponsRequesttQueue = "PlayedCouponsApi_GetRequesttQueue";

        public const string MoneyTransactionsApi_MoneyDecreaseEventqueue = "MoneyTransactionsApi_MoneyDecreaseEventqueue";

        public const string BettingWebSiteBackup_GetCouponsEventqueue = "BettingWebSiteBackup_GetCouponsEventqueue";

        public const string BasketApi_ClearBasketEventqueue = "BasketApi_ClearBasketEventqueue";

        public const string MoneyTransactionApi_AddMoneyEventqueue = "MoneyTransactionApi_AddMoneyEventqueue";

        public const string PlayedCouponsApi_CouponsComplatedEventqueue = "PlayedCouponsApi_CouponsComplatedEventqueue";

        public const string PlayedCouponsApi_CouponsFailedEventqueue = "PlayedCouponsApi_CouponsFailedEventqueue";

        public const string MailApi_MailSentEventqueue = "MailApi_MailSentEventqueue";

        public const string CustomerTransactionsApi_MailGetEventQueue = "CustomerTransactionsApi_MailGetEventQueue";

        public const string CustomerTransactionsApi_MailGetEventResponseQueue = "CustomerTransactionsApi_MailGetEventResponseQueue";

        public const string BettingWebSite_MailGetEventResponseQueue = "BettingWebSite_MailGetEventResponseQueue";

        public const string UserInterface_MailGetEventResponseQueue = "UserInterface_MailGetEventResponseQueue";
    }
}
