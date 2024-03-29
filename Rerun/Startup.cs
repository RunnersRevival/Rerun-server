using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using Rerun.Models.DbModels;

namespace Rerun
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private DateTime StartupTime;

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Add(new ServiceDescriptor(typeof(OutrunDbContext), new OutrunDbContext(Configuration.GetConnectionString("DefaultConnection"))));
            // TODO: Migrate to RerunDbContext
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rerun", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StartupTime = DateTime.Now;

            if (env.IsDevelopment())
            {
                // not sure how useful this'll be, but it's there nonetheless
                Console.WriteLine(@"!!! DEVELOPMENT ENVIRONMENT !!!");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rerun v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // index page; return info about Rerun
                endpoints.MapGet("/", async context =>
                {
                    //context.Response.StatusCode = 404;
                    var version = Assembly.GetEntryAssembly()?.GetName().Version;
                    string displayableVersion;
                    if (version is not null)
                    {
                        var buildDate = new DateTime(2000, 1, 1)
                            .AddDays(version.Build).AddSeconds(version.Revision * 2);
                        displayableVersion = $"{version} (commit {Properties.Resources.CurrentCommit.Trim()}, built {buildDate})";
                    }
                    else
                        displayableVersion = "[unknown]";
                    var versionString = "v" + displayableVersion + " " +
                        (env.IsDevelopment() ? "DEV " : "PROD ") +
#if DEBUG
                        "DEBUG";
#else
                        "RELEASE";
#endif
                    await context.Response.WriteAsync("OK - Rerun " + versionString);
                });

                // generates a 204 No Content response, intended for uptime monitoring
                endpoints.MapGet("/generate204", async context =>
                {
                    context.Response.StatusCode = 204;
                    await context.Response.WriteAsync("");
                });

                // robots.txt, for preventing Rerun from being picked up by compliant web crawlers
                endpoints.MapGet("/robots.txt", async context =>
                {
                    await context.Response.WriteAsync("User-agent: *\nDisallow: /");
                });

                // humans.txt, for a human-readable description of the current Rerun instance
                endpoints.MapGet("/humans.txt", async context =>
                {
                    // TODO: make this customizable
                    await context.Response.WriteAsync("This is a Rerun instance. Rerun is an advanced custom server for Sonic Runners, a defunct mobile game by SEGA. It has been written by a passionate group of fans for the Sonic Runners Revival service. If you wish to contribute to Rerun, the source code is located here: https://github.com/RunnersRevival/Rerun-server (note that the server code may not line up with what is currently live)");
                });

                endpoints.MapControllers();
            });
        }
    }
}
