using System;

namespace Integration.DanceCore
{
    public interface ILibraryLogger
    {
        void Log(LogEntry entry);
    }

    public enum LoggingEventType { Debug, Information, Warning, Error, Fatal };

    public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            if (string.IsNullOrEmpty(message)) { throw new ArgumentNullException("message"); }

            this.Severity = severity;
            this.Message = message;
            this.Exception = exception;
        }
    }
}
