using System;
using AgentFramework.Core.Handlers;
using CloudAgentRouting.Handlers;

namespace CloudAgent.Web
{
    public class CloudInboxAgent : AgentBase
    {
        public CloudInboxAgent(IServiceProvider provider) : base(provider)
        {
        }

        protected override void ConfigureHandlers()
        {
            AddConnectionHandler();
            AddDiscoveryHandler();
            AddHandler<ForwardMessageHandler>();
            AddHandler<AddInboxDeviceHandler>();
            AddHandler<AddInboxDeviceHandler>();
            AddHandler<CreateInboxHandler>();
            AddHandler<GetMessagesHandler>();
            AddHandler<DeleteMessagesHandler>();
        }
    }
}
