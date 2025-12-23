using System;
using System.Collections.Generic;
namespace UniLog.Loggers
{
    public class UnityDebugLogger : ILogger
    {
        public void Info(string message)
        {
            UnityEngine.Debug.Log($"{message}");
        }

        public void Warn(string message)
        {
            UnityEngine.Debug.LogWarning($"{message}");
        }

        public void Error(string message)
        {
            UnityEngine.Debug.LogError($"{message}");
        }
    }
}
