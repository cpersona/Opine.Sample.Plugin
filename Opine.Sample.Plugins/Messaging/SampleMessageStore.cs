using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opine.Messaging;
using Opine.Sample.Plugins.Domain.Customers;
using Opine.Sample.Plugins.Domain.Customers.Commands;

namespace Opine.Sample.Plugins.Messaging
{
    public class SampleMessageStore : IMessageStore
    {
        private static Guid[] aggregateIds = new[] 
        {  
            Guid.NewGuid(),
            Guid.NewGuid(),
        };

        private List<StoredMessage> messages = 
            new List<StoredMessage>() 
            {
                new StoredMessage(
                    Guid.NewGuid(),
                    new Stream("events"),
                    new Metadata(aggregateIds[0]),
                    new Created("Customer1", "GOLD", DateTime.Parse("1/1/2018")),
                    0L,
                    DateTime.Now,
                    "user1"),
                new StoredMessage(
                    Guid.NewGuid(),
                    new Stream("events"),
                    new Metadata(aggregateIds[0]),
                    new SubscriptionAdded("PLATINUM", DateTime.Parse("2/1/2018")),
                    1L,
                    DateTime.Now,
                    "user1"),
                new StoredMessage(
                    Guid.NewGuid(),
                    new Stream("commands"),
                    new Metadata(aggregateIds[1]),
                    new Create("Customer1", "GOLD", DateTime.Parse("1/1/2018")),
                    2L,
                    DateTime.Now,
                    "user1"),
                new StoredMessage(
                    Guid.NewGuid(),
                    new Stream("commands"),
                    new Metadata(aggregateIds[1]),
                    new AddSubscription("PLATINUM", DateTime.Parse("2/1/2018")),
                    3L,
                    DateTime.Now,
                    "user1"),
            };
        public async Task<IEnumerable<StoredMessage>> Read(Stream stream, long position, int count)
        {
            return messages.Where(x => x.Stream.Equals(stream)).Skip((int)position).Take(count).ToArray();
        }

        public async Task Store(Stream stream, long version, IEnumerable<StorableMessage> storableMessages)
        {
            messages.AddRange(storableMessages.Select(x => 
                new StoredMessage(
                    Guid.NewGuid(),
                    stream,
                    x.Metadata,
                    x.Data,
                    0L,
                    DateTime.Now,
                    "user1")));
        }
    }
}