using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Rerun.Logging;

public static class RerunConsoleLoggerExtensions
{
    public static ILoggingBuilder AddRerunConsoleLogger(
        this ILoggingBuilder builder)
    {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, RerunConsoleLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <RerunConsoleLoggerConfig, RerunConsoleLoggerProvider>(builder.Services);

        return builder;
    }
}