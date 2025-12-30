using UnityEngine;

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
            return $"[{source}] {message}";
        }

        public void Info(string message)
        {
            string formatted = GetFormattedMessage(message);
            logger.Info(prefix ? $"[INFO] {formatted}" : formatted);
        }

        public void Warn(string message)
        {
            string formatted = GetFormattedMessage(message);
            logger.Warn(prefix ? $"[WARNING] {formatted}" : formatted);
        }

        public void Error(string message)
        {
            string formatted = GetFormattedMessage(message);
            logger.Error(prefix ? $"[ERROR] {formatted}" : formatted);
        }
    }
}
