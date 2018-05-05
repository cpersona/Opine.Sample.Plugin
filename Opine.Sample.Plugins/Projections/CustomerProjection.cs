using Opine.Dispatching;
using Opine.Sample.Plugins.Domain.Customers;

namespace Opine.Sample.Plugins.Projections
{
    /// <summary>
    /// Projection class for the Customer table.
    /// </summary>
    [HandlerClass(HandlerType.Event)]
    public class CustomerProjection
    {
        // Inject the connection
        
        [HandlerMethod()]
        public void Handle(MessageContext context, Created e)
        {
            // Dapper work... Insert into table
        }
    }
}