using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    public class CreateInboxHandler : MessageHandlerBase<CreateInbox>
    {
        private readonly IInboxService _inboxService;

        public CreateInboxHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        protected override async Task<AgentMessage> ProcessAsync(CreateInbox message, IAgentContext agentContext)
        {
            await _inboxService.CreateAsync(agentContext, message);
            return null;
        }
    }
}
