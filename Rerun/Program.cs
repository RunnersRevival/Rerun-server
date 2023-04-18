using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using Rerun.Logging;

namespace Rerun
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
                var netVersion = Environment.Version;
                displayableVersion = $"{version} (commit {Properties.Resources.CurrentCommit.Trim()}, built {buildDate}) (running on .NET {netVersion})";
            }
            else
                displayableVersion = "[unknown]";
#if DEBUG
            displayableVersion += " (debug)";
#endif
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"Rerun v" + displayableVersion);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WARNING: This is WORK-IN-PROGRESS software. It is not recommended to use this in production, as the Rerun database spec has not been finalized yet.");
            Console.ForegroundColor = ConsoleColor.Gray;

            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddRerunConsoleLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
