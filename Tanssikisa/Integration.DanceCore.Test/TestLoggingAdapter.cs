using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration.DanceCore;

namespace Integration.DanceCore.Test
{
    public sealed class TestLoggingAdapter : ILibraryLogger
    {
        public List<LogEntry> LogEntries;

        public TestLoggingAdapter()
        {
            LogEntries = new List<LogEntry>();
        }

        public void Log(LogEntry entry)
        {
            LogEntries.Add(entry);
        }
    }
}
