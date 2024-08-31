using Integration.DanceCore;

namespace Tanssikisa.Blazor.Adapters
{
    public sealed class MicrosoftLoggingAdapter(ILogger adaptee) : ILibraryLogger
    {
        private readonly ILogger adaptee = adaptee;

        public void Log(LogEntry e) =>
            adaptee.Log(ToLevel(e.Severity), 0, e.Message, e.Exception, (s, _) => s);

        private static LogLevel ToLevel(LoggingEventType s) =>
            LoggingEventType.Debug == s ? LogLevel.Debug :
            LoggingEventType.Information == s ? LogLevel.Information :
            LoggingEventType.Warning == s ? LogLevel.Warning :
            LoggingEventType.Error == s ? LogLevel.Error :
            LogLevel.Critical;
    }
}
