using System;

namespace ScrumCeremony.Utils
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            // write to window or some other medium
            Console.WriteLine(message);
        }

        public void Log(Exception ex, string message)
        {
            Log(string.Format("Exception: {0}, Message: {1}", ex.Message, message));
        }
    }
}