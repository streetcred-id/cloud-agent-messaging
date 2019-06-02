using System;
using System.Threading.Tasks;
using AgentFramework.AspNetCore;
using CloudAgentRouting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CloudAgent.Client
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        static async Task Main(string[] args)
        {
            using (var host = CreateWebHostBuilder(args).Build())
            {
                await host.StartAsync();

                await host.StopAsync();
            }
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) => 
            new HostBuilder()
                .ConfigureServices(services => services.AddAgentFramework(b => b.AddInbox()))
                .ConfigureHostConfiguration(config => Configuration = config.Build());
    }
}