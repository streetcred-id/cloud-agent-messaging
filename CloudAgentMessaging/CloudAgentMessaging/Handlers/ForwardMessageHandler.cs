using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using AgentFramework.Core.Messages.Routing;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    public class ForwardMessageHandler : MessageHandlerBase<ForwardMessage>
    {
        private readonly IInboxService _inboxService;

        public ForwardMessageHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        /// <summary>
        /// Process incoming forward message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="agentContext"></param>
        /// <returns></returns>
        protected override async Task<AgentMessage> ProcessAsync(ForwardMessage message, IAgentContext agentContext)
        {
            await _inboxService.ForwardAsync(message.Message, message.To, agentContext);
            return null;
        }
    }
}
