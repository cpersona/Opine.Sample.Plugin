using System;
using Opine.Domain;

namespace Opine.Sample.Plugins.Domain.Customers.Commands
{
    public class AddSubscription : ICommand
    {
        private AddSubscription() { }

        public AddSubscription(string levelCode, DateTime startDate)
        {
            LevelCode = levelCode;
            StartDate = startDate;
        }

        public string LevelCode { get; private set; }
        public DateTime StartDate { get; private set; }
    }
}