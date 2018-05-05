using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Opine.Dispatching;
using Opine.Dispatching.Dynamic;
using Opine.Messaging;
using Opine.Plugins;
using Opine.Repositories;
using Opine.Repositories.EventSourced;
using Opine.Sample.Plugins.Dispatching;
using Opine.Sample.Plugins.Messaging;
using Opine.Sample.Plugins.Snapshots;
using Opine.Snapshots;

namespace Opine.Sample.Plugins
{
    public class SamplePlugin : IPlugin
    {
        private Lazy<IEnumerable<HandlerInfo>> handlers;

        public SamplePlugin()
        {
            handlers = new Lazy<IEnumerable<HandlerInfo>>(() => 
                (new HandlerFinder()).FindHandlers(Assembly.GetExecutingAssembly()));
        }

        public void ParseArguments(string[] args)
        {
            // Nothing to parse here
        }

        public void RegisterHandlers(IHandlerRegistry handlerRegistry)
        {
            foreach (var hi in handlers.Value)
            {
                handlerRegistry.Register(hi.MessageType, new HandlerInfo(hi.HandlerType,
                    hi.MessageType, hi.ProcessCode, hi.MethodInfo));
            }
        }

        public void RegisterServices(IServiceCollection collection)
        {
            foreach (var hi in handlers.Value)
            {
                collection.AddScoped(hi.MethodInfo.DeclaringType);
            }

            collection
                .AddScoped<IHandlerFinder, HandlerFinder>()
                // Use dynamic dispatching
                .AddScoped<IDispatcher, DynamicDispatcher>()
                .AddScoped<IUnitOfWork, SampleUnitOfWork>()
                // Use event sourcing
                .AddScoped<IRepository, EventSourcedRepository>()
                // Snapshots
                .AddScoped<ISnapshotStore, SampleSnapshotStore>()
                // Messaging (One for use by repositories and one for reading messages in the stream)
                .AddSingleton<IMessageStore, SampleMessageStore>()
                .AddScoped<IMessageReader>(s => 
                    s.GetRequiredService<IMessageStore>());
        }
    }
}