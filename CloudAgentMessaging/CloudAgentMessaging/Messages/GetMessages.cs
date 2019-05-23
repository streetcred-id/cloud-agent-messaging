using System;
using AgentFramework.Core.Messages;
using Newtonsoft.Json;

namespace CloudAgentRouting.Messages
{
    public class GetMessages : AgentMessage
    {
        public GetMessages()
        {
            Type = "get_messages";
        }

        [JsonProperty("identifiers")]
        public string[] Identifiers { get; set; }
    }
}