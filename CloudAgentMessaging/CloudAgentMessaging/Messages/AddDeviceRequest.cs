using System;
using AgentFramework.Core.Messages;

namespace CloudAgentMessaging.Messages
{
    public class AddDeviceRequest : AgentMessage
    {
        public AddDeviceRequest()
        {
            Type = "add_device_request";
        }
    }
}
