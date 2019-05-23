using System;
using AgentFramework.Core.Messages;

namespace CloudAgentRouting.Messages
{
    public class GetMessagesResponse : AgentMessage
    {
        public GetMessagesResponse()
        {
            Type = "get_messages_response";
        }

        public string[] Messages { get; set; }
    }
}
