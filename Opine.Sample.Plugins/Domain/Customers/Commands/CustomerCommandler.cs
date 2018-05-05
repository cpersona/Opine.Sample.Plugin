using Opine.Dispatching;

namespace Opine.Sample.Plugins.Domain.Customers.Commands
{
    [HandlerClass(HandlerType.Command)]
    public class CustomerCommandler
    {
        [HandlerMethod]
        public void Handle(Create c, CustomerAggregate customer)
        {
            customer.Create(c.CustomerName, c.LevelCode, c.StartDate);
        }

        [HandlerMethod]
        public void Handle(AddSubscription c, CustomerAggregate customer)
        {
            customer.ChangeSubscription(c.LevelCode, c.StartDate);
        }

        [HandlerMethod]
        public void Handle(RemoveSubscription c, CustomerAggregate customer)
        {
            customer.RemoveSubscription(c.EndDate);
        }
    }
}