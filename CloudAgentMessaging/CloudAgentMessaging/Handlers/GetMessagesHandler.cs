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

        /// <inheritdoc />
        protected override async Task<AgentMessage> ProcessAsync(GetMessages message, IAgentContext agentContext, MessageContext messageContext)
        {
            return await _inboxService.GetMessagesAsync(agentContext, messageContext, message);
        }
    }
}
