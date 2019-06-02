using System;
using AgentFramework.AspNetCore;
using CloudAgentRouting.Handlers;
using CloudAgentRouting.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CloudAgentRouting
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInbox(this AgentBuilder builder)
        {
            var collection = builder.Services;

            collection.TryAddSingleton<IInboxService, MemoryInboxService>();

            collection.TryAddSingleton<ForwardMessageHandler>();
            collection.TryAddSingleton<AddInboxDeviceHandler>();
            collection.TryAddSingleton<AddInboxDeviceHandler>();
            collection.TryAddSingleton<CreateInboxHandler>();
            collection.TryAddSingleton<GetMessagesHandler>();
            collection.TryAddSingleton<DeleteMessagesHandler>();
        }

        public static void AddInbox<T>(this AgentBuilder builder)
            where T : class, IInboxService
        {
            var collection = builder.Services;

            collection.TryAddSingleton<IInboxService, T>();

            collection.TryAddSingleton<ForwardMessageHandler>();
            collection.TryAddSingleton<AddInboxDeviceHandler>();
            collection.TryAddSingleton<AddInboxDeviceHandler>();
            collection.TryAddSingleton<CreateInboxHandler>();
            collection.TryAddSingleton<GetMessagesHandler>();
            collection.TryAddSingleton<DeleteMessagesHandler>();
        }
    }
}
