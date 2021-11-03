using System;
using System.Diagnostics;

public enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        var parsedLevel = logLine.Substring(1, 3);

        switch (parsedLevel)
        {
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "INF":
                return LogLevel.Info;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        int logLevelNumber;
        
        switch (logLevel)
        {
            case LogLevel.Unknown:
                logLevelNumber = 0;
                break;
            case LogLevel.Trace:
                logLevelNumber = 1;
                break;
            case LogLevel.Debug:
                logLevelNumber = 2;
                break;
            case LogLevel.Info:
                logLevelNumber = 4;
                break;
            case LogLevel.Warning:
                logLevelNumber = 5;
                break;
            case LogLevel.Error:
                logLevelNumber = 6;
                break;
            default:
                logLevelNumber = 42;
                break;
        }

        return $"{logLevelNumber}:{message}";
    }
}