using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;

namespace CloudAgentRouting.Services
{
    public class MemoryInboxService : IInboxService
    {
        readonly Dictionary<string, string> _routes = new Dictionary<string, string>();
        readonly Dictionary<string, List<StorageMessage>> _storage = new Dictionary<string, List<StorageMessage>>();

        public Task AddDeviceAsync(IAgentContext context, MessageContext messageContext, AddInboxDevice inboxDevice)
        {
            return Task.CompletedTask;
        }

        public Task AddRecipientAsync(IAgentContext context, MessageContext messageContext, AddInboxRecipient inboxRecipient)
        {
            _routes.Add(inboxRecipient.Recipient, messageContext.Connection.Id);
            return Task.CompletedTask;
        }

        public Task CreateAsync(IAgentContext context, MessageContext messageContext, CreateInbox createInbox)
        {
            _storage.Add(messageContext.Connection.Id, new List<StorageMessage>());
            return Task.CompletedTask;
        }

        public Task DeleteMessagesAsync(IAgentContext context, MessageContext messageContext, DeleteMessages deleteMessages)
        {
            throw new NotImplementedException();
        }

        public Task ForwardAsync(string message, string recipient, IAgentContext agentContext, MessageContext messageContext)
        {
            var inboxId = _routes[recipient];
            _storage[inboxId].Add(new StorageMessage { Message = message });
            return Task.CompletedTask;
        }

        public Task<GetMessagesResponse> GetMessagesAsync(IAgentContext context, MessageContext messageContext, GetMessages getMessages)
        {
            var response = new GetMessagesResponse
            {
                Messages = _storage[messageContext.Connection.Id].Select(x => x.Message).ToArray()
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
