using System;
using Opine.Domain;

namespace Opine.Sample.Plugins.Domain.Customers.Commands
{
    public class RemoveSubscription : ICommand
    {
        private RemoveSubscription() { }

        public RemoveSubscription(DateTime endDate)
        {
            EndDate = endDate;
        }

        public DateTime EndDate { get; private set; }
    }
}