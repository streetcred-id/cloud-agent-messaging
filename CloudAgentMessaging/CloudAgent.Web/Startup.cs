using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentFramework.AspNetCore;
using AgentFramework.Core.Models.Wallets;
using CloudAgentRouting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CloudAgent.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAgentFramework(builder =>
            {
                builder.AddInbox();
                builder.AddBasicAgent<CloudInboxAgent>(config =>
                {
                    config.EndpointUri = new Uri(
                        Environment.GetEnvironmentVariable("ENDPOINT_HOST") ??
                        Environment.GetEnvironmentVariable("ASPNETCORE_URLS"));
                    config.WalletConfiguration = new WalletConfiguration { Id = "CloudInboxWallet" };
                    config.WalletCredentials = new WalletCredentials { Key = "1234567890" };
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAgentFramework();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
