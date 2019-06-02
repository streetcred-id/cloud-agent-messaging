using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers.Agents;
using AgentFramework.Core.Models.Records;
using Microsoft.AspNetCore.Mvc;

namespace CloudAgent.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IProvisioningService provisioningService;
        private readonly IAgentProvider agentProvider;

        public ValuesController(
            IProvisioningService provisioningService,
            IAgentProvider agentProvider)
        {
            this.provisioningService = provisioningService;
            this.agentProvider = agentProvider;
        }

        [HttpGet]
        public async Task<ProvisioningRecord> GetConfiguration()
        {
            var agentContext = await agentProvider.GetContextAsync();
            var record = await provisioningService.GetProvisioningAsync(agentContext.Wallet);

            return record;
        }
    }
}
