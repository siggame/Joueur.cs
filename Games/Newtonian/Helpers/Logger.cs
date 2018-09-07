using System;

namespace Joueur.cs.Games.Newtonian.Helpers
{
    public static class Logger
    {
        public static bool Logging = true;
        public static LogLevel Level = LogLevel.TRACE;

        public static void Log(string message, LogLevel level = LogLevel.INFO)
        {
            if (!Logger.Logging)
                return;

            if (Logger.Level > level)
                return;

            Console.WriteLine(message);
        }

        public enum LogLevel {
            TRACE,
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }
    }
}
