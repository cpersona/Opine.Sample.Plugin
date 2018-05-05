using System;
using System.Collections.Generic;
using System.Linq;
using Opine.Domain;
using Opine.Domain.EventSourced;

namespace Opine.Sample.Plugins.Domain.Customers
{
    public class CustomerAggregate : EventSourcedAggregateBase<Customer>
    {
        public CustomerAggregate(Customer root, long version, IEnumerable<IEvent> events) : base(root, version, events)
        {
        }

        protected override void Apply(IEvent e)
        {
            switch (e)
            {
                case Created evt:
                    Root.CustomerName = evt.CustomerName;
                    break;

                case SubscriptionAdded evt:
                    Root.Subscriptions.Add(new Subscription(evt.LevelCode, evt.StartDate));
                    break;

                case SubscriptionRemoved evt:
                    var s = Root.Subscriptions.LastOrDefault();
                    s?.SetEndDate(evt.EndDate);
                    break;

                default:
                    throw new InvalidOperationException($"Unknown event type {e.GetType().Name}");
            }
        }

        public void Create(string customerName, string levelCode, DateTime startDate)
        {
            if (!string.IsNullOrWhiteSpace(Root.CustomerName)) return;
            Root.CustomerName = customerName;
            Root.Subscriptions.Add(new Subscription(levelCode, startDate));
            Emit(new Created(customerName, levelCode, startDate));
        }

        public void ChangeSubscription(string levelCode, DateTime startDate)
        {
            var last = Root.Subscriptions.LastOrDefault();
            if ((last?.LevelCode).EqualsTo(levelCode)) return;
            Root.Subscriptions.Add(new Subscription(levelCode, startDate));
            Emit(new SubscriptionAdded(levelCode, startDate));
        }

        public void RemoveSubscription(DateTime endDate)
        {
            var last = Root.Subscriptions.Last();
            if (last.EndDate == endDate) return;
            last.SetEndDate(endDate);
            Emit(new SubscriptionRemoved(endDate));
        }
    }
}