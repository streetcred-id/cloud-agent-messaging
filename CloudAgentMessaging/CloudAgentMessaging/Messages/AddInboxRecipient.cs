using System;
using AgentFramework.Core.Messages;
using Newtonsoft.Json;

namespace CloudAgentRouting.Messages
{
    public class AddInboxRecipient : AgentMessage
    {
        public AddInboxRecipient()
        {
            Type = "add_inbox_recipient";
        }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }
    }
}
