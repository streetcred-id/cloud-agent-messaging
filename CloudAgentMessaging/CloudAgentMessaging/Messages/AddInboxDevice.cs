using System;
using AgentFramework.Core.Messages;
using Newtonsoft.Json;

namespace CloudAgentRouting.Messages
{
    public class AddInboxDevice : AgentMessage
    {
        public AddInboxDevice()
        {
            Type = "add_inbox_consumer";
        }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
    }
}
