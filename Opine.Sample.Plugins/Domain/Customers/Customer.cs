using System.Collections.Generic;

namespace Opine.Sample.Plugins.Domain.Customers
{
    public class Customer
    {
        public Customer()
        {
            Subscriptions = new List<Subscription>();
        }

        public string CustomerName { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}