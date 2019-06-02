using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    public class AddInboxRecipientHandler : MessageHandlerBase<AddInboxRecipient>
    {
        private readonly IInboxService _inboxService;

        public AddInboxRecipientHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        protected override async Task<AgentMessage> ProcessAsync(AddInboxRecipient message, IAgentContext agentContext, MessageContext messageContext)
        {
            await _inboxService.AddRecipientAsync(agentContext, messageContext, message);
            return null;
        }
    }
}
