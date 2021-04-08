using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace OutrunSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
#if DEBUG
            displayableVersion += " (debug)";
#endif
            Console.WriteLine("OutrunSharp v" + displayableVersion);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
