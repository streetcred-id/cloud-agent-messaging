using System;
using AgentFramework.Core.Messages;

namespace CloudAgentMessaging.Messages
{
    public class AddRouteResponse : AgentMessage
    {
        public AddRouteResponse()
        {
            Type = "add_route_response";
        }
    }
}
