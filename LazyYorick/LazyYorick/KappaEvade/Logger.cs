using System;
// ReSharper disable StringLiteralsWordIsNotInDictionary

namespace LazyYorick.KappaEvade
{
    internal class Logger
    {
        public enum LogLevel
        {
            Error,
            Info,
            Warn
        }

        public static bool Send(string str, LogLevel level)
        {
            var date = DateTime.Now.ToString("[H:mm:ss - ") + "LazyYorick/KappaEvade ";
            var text = string.Empty;
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    text = date + " Info] ";
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    text = date + " Warn] ";
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    text = date + " Error] ";
                    break;
            }
            Console.WriteLine(text + str);
            Console.ResetColor();
            return true;
        }

        public static void Send(string str, Exception ex, LogLevel level)
        {
            var date = DateTime.Now.ToString("[H:mm:ss - ") + "LazyYorick/KappaEvade ";
            var text = string.Empty;
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    text = date + " Info] ";
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    text = date + " Warn] ";
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    text = date + " Error] ";
                    break;
            }
            Console.WriteLine(text);
            Console.WriteLine(ex);
            Console.ResetColor();
        }
    }
}
