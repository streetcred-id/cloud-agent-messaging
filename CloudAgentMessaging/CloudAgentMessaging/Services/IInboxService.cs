using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;

namespace CloudAgentRouting.Services
{
    public interface IInboxService
    {
        Task CreateAsync(IAgentContext context, MessageContext messageContext, CreateInbox createInbox);

        Task AddDeviceAsync(IAgentContext context, MessageContext messageContext, AddInboxDevice inboxDevice);

        Task AddRecipientAsync(IAgentContext context, MessageContext messageContext, AddInboxRecipient inboxRecipient);

        Task<GetMessagesResponse> GetMessagesAsync(IAgentContext context, MessageContext messageContext, GetMessages getMessages);

        Task ForwardAsync(string message, string recipient, IAgentContext agentContext, MessageContext messageContext);

        Task DeleteMessagesAsync(IAgentContext context, MessageContext messageContext, DeleteMessages deleteMessages);
    }
}
