using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Rerun.Logging;

public class RerunConsoleLoggerConfig
{
    public int EventId { get; set; }

    public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new()
    {
        [LogLevel.Trace] = ConsoleColor.Gray,
        [LogLevel.Debug] = ConsoleColor.DarkGreen,
        [LogLevel.Information] = ConsoleColor.Cyan,
        [LogLevel.Warning] = ConsoleColor.Yellow,
        [LogLevel.Error] = ConsoleColor.Magenta,
        [LogLevel.Critical] = ConsoleColor.Red
    };
}