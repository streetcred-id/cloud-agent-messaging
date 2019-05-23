using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    public class GetMessagesHandler : MessageHandlerBase<GetMessages>
    {
        private readonly IInboxService _inboxService;

        public GetMessagesHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        protected override async Task<AgentMessage> ProcessAsync(GetMessages message, IAgentContext agentContext)
        {
            return await _inboxService.GetMessagesAsync(agentContext, message);
        }
    }
}
