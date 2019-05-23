using System;
using AgentFramework.Core.Messages;
using Newtonsoft.Json;

namespace CloudAgentRouting.Messages
{
    public class DeleteMessages : AgentMessage
    {
        public DeleteMessages()
        {
            Type = "delete_inbox_messages";
        }

        [JsonProperty("identifiers")]
        public string[] Identifiers { get; set; }
    }
}
