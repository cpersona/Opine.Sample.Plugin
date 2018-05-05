using Opine.Dispatching;
using Opine.Sample.Plugins.Domain.Customers;

namespace Opine.Sample.Plugins.Projections
{
    [HandlerClass(HandlerType.Event)]
    public class CustomerSubscriptionProjection
    {
        // Inject connection

        [HandlerMethod()]
        public void Handle(MessageContext c, SubscriptionAdded e)
        {
            // Insert into the table
        }

        [HandlerMethod()]
        public void Handle(MessageContext c, SubscriptionRemoved e)
        {
            // Update the end date
        }
    }
}