using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using AgentFramework.Core.Messages.Routing;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    /// <summary>
    /// Handler for unpacking forward messages
    /// </summary>
    public class ForwardMessageHandler : MessageHandlerBase<ForwardMessage>
    {
        private readonly IInboxService _inboxService;

        public ForwardMessageHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        /// <inheritdoc />
        protected override async Task<AgentMessage> ProcessAsync(ForwardMessage message, IAgentContext agentContext, MessageContext messageContext)
        {
            await _inboxService.ForwardAsync(message.Message, message.To, agentContext, messageContext);
            return null;
        }
    }
}
