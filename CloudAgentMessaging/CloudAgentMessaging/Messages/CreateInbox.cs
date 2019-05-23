using System;
using AgentFramework.Core.Messages;

namespace CloudAgentRouting.Messages
{
    public class CreateInbox : AgentMessage
    {
        public CreateInbox()
        {
            Type = "create_inbox";
        }
    }
}
