using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using CloudAgentRouting.Messages;

namespace CloudAgentRouting.Services
{
    public class MemoryInboxService : IInboxService
    {
        readonly Dictionary<string, string> _routes = new Dictionary<string, string>();
        readonly Dictionary<string, List<StorageMessage>> _storage = new Dictionary<string, List<StorageMessage>>();

        public Task AddDeviceAsync(IAgentContext context, AddInboxDevice inboxDevice)
        {
            return Task.CompletedTask;
        }

        public Task AddRecipientAsync(IAgentContext context, AddInboxRecipient inboxRecipient)
        {
            _routes.Add(inboxRecipient.Recipient, context.Connection.Id);
            return Task.CompletedTask;
        }

        public Task CreateAsync(IAgentContext context, CreateInbox createInbox)
        {
            _storage.Add(context.Connection.Id, new List<StorageMessage>());
            return Task.CompletedTask;
        }

        public Task DeleteMessagesAsync(IAgentContext context, DeleteMessages deleteMessages)
        {
            throw new NotImplementedException();
        }

        public Task ForwardAsync(string message, string recipient, IAgentContext agentContext)
        {
            var inboxId = _routes[recipient];
            _storage[inboxId].Add(new StorageMessage { Message = message });
            return Task.CompletedTask;
        }

        public Task<GetMessagesResponse> GetMessagesAsync(IAgentContext context, GetMessages getMessages)
        {
            var response = new GetMessagesResponse
            {
                Messages = _storage[context.Connection.Id].Select(x => x.Message).ToArray()
            };
            return Task.FromResult(response);
        }
    }

    public class StorageMessage
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}
