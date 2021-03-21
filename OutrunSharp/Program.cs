using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace OutrunSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion = $"{version} (commit {Properties.Resources.CurrentCommit.Trim()}, built {buildDate})";
            Console.WriteLine("OutrunSharp v" + displayableVersion);
#if DEBUG
            Console.WriteLine("!!! DEBUG BUILD !!!");
#endif
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
