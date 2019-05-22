using System;
using AgentFramework.Core.Messages;

namespace CloudAgentMessaging.Messages
{
    public class AddRouteRequest : AgentMessage
    {
        public AddRouteRequest()
        {
            Type = "add_route_request";
        }


        public string DidOrKey { get; set; }
    }
}
