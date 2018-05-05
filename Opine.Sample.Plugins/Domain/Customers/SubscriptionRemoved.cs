using System;
using Opine.Domain;

namespace Opine.Sample.Plugins.Domain.Customers
{
    public class SubscriptionRemoved : IEvent
    {
        private SubscriptionRemoved() { }

        public SubscriptionRemoved(DateTime endDate)
        {
            EndDate = endDate;
        }

        public DateTime EndDate { get; set; }
    }
}