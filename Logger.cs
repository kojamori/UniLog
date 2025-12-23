using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniLog
{
    public class Logger : ILogger
    {
        private readonly ILogger logger;
        private readonly string source;
        private readonly bool prefix;

        public Logger(ILogger logger, string source, bool prefix = false)
        {
            this.logger = logger;
            this.source = source;
            this.prefix = prefix;
        }

        private string GetFormattedMessage(string message)
        {
            return prefix ? $"[{source}] {message}" : message;
        }

        public void Info(string message)
        {
            logger.Info(GetFormattedMessage(message));
        }

        public void Warn(string message)
        {
            logger.Warn(GetFormattedMessage(message));
        }

        public void Error(string message)
        {
            logger.Error(GetFormattedMessage(message));
        }
    }
}
