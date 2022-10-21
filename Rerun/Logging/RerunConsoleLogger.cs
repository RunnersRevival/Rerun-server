using System;
using Microsoft.Extensions.Logging;

namespace Rerun.Logging;

public class RerunConsoleLogger : ILogger
{
    private readonly string _name;
    private readonly Func<RerunConsoleLoggerConfig> _getCurrentConfig;

    public RerunConsoleLogger(
        string name,
        Func<RerunConsoleLoggerConfig> getCurrentConfig) =>
        (_name, _getCurrentConfig) = (name, getCurrentConfig);
    
    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        _getCurrentConfig().LogLevels.ContainsKey(logLevel);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var config = _getCurrentConfig();
        if (config.EventId != 0 && config.EventId != eventId.Id) return;
        var originalColor = Console.ForegroundColor;
            
        Console.Write($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}] [");
            
        Console.ForegroundColor = config.LogLevels[logLevel];
        switch (logLevel)
        {
            case LogLevel.Trace:
                Console.Write("TRACE");
                break;
            case LogLevel.Debug:
                Console.Write("DEBUG");
                break;
            case LogLevel.Information:
                Console.Write("INFO");
                break;
            case LogLevel.Warning:
                Console.Write("WARN");
                break;
            case LogLevel.Error:
                Console.Write("ERROR");
                break;
            case LogLevel.Critical:
                Console.Write("FATAL");
                break;
            case LogLevel.None:
            default:
                Console.Write("LOG");
                break;
        }
        //Console.Write($"{logLevel,-12}");
            
        Console.ForegroundColor = originalColor;
        Console.WriteLine($"] ({_name}) {formatter(state, exception)}");
    }
}