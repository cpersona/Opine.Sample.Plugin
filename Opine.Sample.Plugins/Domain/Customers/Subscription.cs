using System;

namespace Opine.Sample.Plugins.Domain.Customers
{
    public class Subscription
    {
        private Subscription() { }

        public Subscription(string levelCode, DateTime startDate)
        {
            LevelCode = levelCode;
            StartDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }

        public string LevelCode { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
    }
}