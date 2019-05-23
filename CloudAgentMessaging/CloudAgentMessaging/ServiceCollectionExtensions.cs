using System;
using CloudAgentRouting.Handlers;
using CloudAgentRouting.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CloudAgentRouting
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAgentInbox(this IServiceCollection collection)
        {
            collection.TryAddSingleton<IInboxService, MemoryInboxService>();

            collection.TryAddSingleton<ForwardMessageHandler>();
            collection.TryAddSingleton<AddInboxDeviceHandler>();
            collection.TryAddSingleton<AddInboxDeviceHandler>();
            collection.TryAddSingleton<CreateInboxHandler>();
            collection.TryAddSingleton<GetMessagesHandler>();
            collection.TryAddSingleton<DeleteMessagesHandler>();
        }

        public static void AddAgentInbox<T>(this IServiceCollection collection)
            where T : class, IInboxService
        {
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
