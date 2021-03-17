using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using OutrunSharp.Models.DbModels;

namespace OutrunSharp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Add(new ServiceDescriptor(typeof(OutrunDbContext), new OutrunDbContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OutrunSharp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OutrunSharp v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // index page; return 404 along with some info about OutrunSharp
                endpoints.MapGet("/", async context =>
                {
                    context.Response.StatusCode = 404;
                    Version version = Assembly.GetEntryAssembly().GetName().Version;
                    DateTime buildDate = new DateTime(2000, 1, 1)
                                            .AddDays(version.Build).AddSeconds(version.Revision * 2);
                    string displayableVersion = $"{version} (built {buildDate})";
                    string versionString = "v" + displayableVersion + " " +
                        (env.IsDevelopment() ? "DEV " : "PROD ") +
#if DEBUG
                        "DEBUG";
#else
                        "RELEASE";
#endif
                    await context.Response.WriteAsync("OutrunSharp " + versionString);
                });

                // generates a 204 No Content response, intended for the status page
                endpoints.MapGet("/generate204", async context =>
                {
                    context.Response.StatusCode = 204;
                    await context.Response.WriteAsync("");
                });

                endpoints.MapControllers();
            });
        }
    }
}
