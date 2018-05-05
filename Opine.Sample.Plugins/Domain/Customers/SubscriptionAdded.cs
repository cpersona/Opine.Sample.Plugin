using System;
using Opine.Domain;

namespace Opine.Sample.Plugins.Domain.Customers
{
    public class SubscriptionAdded : IEvent
    {
        private SubscriptionAdded() { }

        public SubscriptionAdded(string levelCode, DateTime startDate)
        {
            LevelCode = levelCode;
            StartDate = startDate;
        }

        public string LevelCode { get; private set; }
        public DateTime StartDate { get; private set; }
    }
}