using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using CloudAgentRouting.Messages;

namespace CloudAgentRouting.Services
{
    public interface IInboxService
    {
        Task CreateAsync(IAgentContext context, CreateInbox createInbox);

        Task AddDeviceAsync(IAgentContext context, AddInboxDevice inboxDevice);

        Task AddRecipientAsync(IAgentContext context, AddInboxRecipient inboxRecipient);

        Task<GetMessagesResponse> GetMessagesAsync(IAgentContext context, GetMessages getMessages);

        Task ForwardAsync(string message, string recipient, IAgentContext agentContext);

        Task DeleteMessagesAsync(IAgentContext context, DeleteMessages deleteMessages);
    }
}
