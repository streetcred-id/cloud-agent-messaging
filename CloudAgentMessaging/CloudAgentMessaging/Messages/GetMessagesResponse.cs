using System;
using AgentFramework.Core.Messages;
using Newtonsoft.Json;

namespace CloudAgentRouting.Messages
{
    public class GetMessagesResponse : AgentMessage
    {
        public GetMessagesResponse()
        {
            Type = "get_messages_response";
        }

        [JsonProperty("messages")]
        public string[] Messages { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}
