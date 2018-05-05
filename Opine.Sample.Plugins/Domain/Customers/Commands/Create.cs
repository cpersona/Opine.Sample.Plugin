using System;
using Opine.Domain;

namespace Opine.Sample.Plugins.Domain.Customers.Commands
{
    public class Create : ICommand
    {
        private Create() { }
        
        public Create(string customerName, string levelCode, DateTime startDate)
        {
            CustomerName = customerName;
            LevelCode = levelCode;
            StartDate = startDate;
        }

        public string CustomerName { get; private set; }
        public string LevelCode { get; private set; }
        public DateTime StartDate { get; private set; }
    }
}