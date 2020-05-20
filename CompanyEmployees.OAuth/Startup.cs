using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyEmployees.OAuth.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanyEmployees.OAuth
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddTestUsers(InMemoryConfig.GetUsers())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential(); // Not for production. Use AddSigningCredentials

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // serve from wwwroot
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();
            app.UseEndpoints(e => e.MapDefaultControllerRoute());
        }
    }
}
