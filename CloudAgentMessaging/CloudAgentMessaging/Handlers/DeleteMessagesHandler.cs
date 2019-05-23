using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    public class DeleteMessagesHandler : MessageHandlerBase<DeleteMessages>
    {
        private readonly IInboxService _inboxService;

        public DeleteMessagesHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        protected override async Task<AgentMessage> ProcessAsync(DeleteMessages message, IAgentContext agentContext)
        {
            await _inboxService.DeleteMessagesAsync(agentContext, message);
            return null;
        }
    }
}
