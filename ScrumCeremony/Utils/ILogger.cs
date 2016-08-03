using System;

namespace ScrumCeremony.Utils
{
    public interface ILogger
    {
        void Log(string message);
        void Log(Exception ex, string message);
    }
}