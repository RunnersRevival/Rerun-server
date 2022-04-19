using System;
using System.Collections.Concurrent;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Rerun.Logging;

[UnsupportedOSPlatform("browser")]
[ProviderAlias("RerunConsole")]
public class RerunConsoleLoggerProvider : ILoggerProvider
{
    private readonly IDisposable _onChangeToken;
    private RerunConsoleLoggerConfig _currentConfig;
    private readonly ConcurrentDictionary<string, RerunConsoleLogger> _loggers =
        new(StringComparer.OrdinalIgnoreCase);

    public RerunConsoleLoggerProvider(
        IOptionsMonitor<RerunConsoleLoggerConfig> config)
    {
        _currentConfig = config.CurrentValue;
        _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
    }

    public ILogger CreateLogger(string categoryName) =>
        _loggers.GetOrAdd(categoryName, name => new RerunConsoleLogger(name, GetCurrentConfig));

    private RerunConsoleLoggerConfig GetCurrentConfig() => _currentConfig;

    public void Dispose()
    {
        _loggers.Clear();
        _onChangeToken.Dispose();
    }
}