using System;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers;
using AgentFramework.Core.Messages;
using CloudAgentRouting.Messages;
using CloudAgentRouting.Services;

namespace CloudAgentRouting.Handlers
{
    public class AddInboxDeviceHandler : MessageHandlerBase<AddInboxDevice>
    {
        private readonly IInboxService _inboxService;

        public AddInboxDeviceHandler(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        protected override async Task<AgentMessage> ProcessAsync(AddInboxDevice message, IAgentContext agentContext)
        {
            await _inboxService.AddDeviceAsync(agentContext, message);
            return null;
        }
    }
}
