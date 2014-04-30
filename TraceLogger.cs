using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Scale.Logger
{
    /// <summary>
    /// Logger object for writing log messages to the system Trace listener.
    /// </summary>
    public class TraceLogger : ILogger
    {
        public TraceLogger(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            Key = key;
        }

        /// <summary>
        /// The Key that identifies this instance of Logger.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Logs a message. message can be a format string with optional args.
        /// </summary>
        public void Message(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Trace.WriteLine(FormatLine("", filePath, memberName, lineNumber, message, args));
        }

        /// <summary>
        /// Logs an information message. message can be a format string with optional args.
        /// </summary>
        public void Info(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Trace.WriteLine(FormatLine("INFO", filePath, memberName, lineNumber, message, args));
        }

        /// <summary>
        /// Logs an error message. message can be a format string with optional args.
        /// </summary>
        public void Error(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Trace.WriteLine(FormatLine("ERROR", filePath, memberName, lineNumber, message, args));
        }

        /// <summary>
        /// Logs an Exception stack trace.
        /// </summary>
        public void Error(Exception exception, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string message = exception == null ? "(Exception is null)" : exception.Message;
            Trace.WriteLine(FormatLine("ERROR", filePath, memberName, lineNumber, message));
            if (exception != null && exception.StackTrace != null)
            {
                Trace.WriteLine(FormatLine("ERROR", filePath, memberName, lineNumber, exception.StackTrace,
                    new object[] { }));
            }
        }

        /// <summary>
        /// Logs an error message and Exception stack trace. message can be a format string with optional args.
        /// </summary>
        public void Error(Exception exception, string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Trace.WriteLine(FormatLine("ERROR", filePath, memberName, lineNumber, message, args));
            if (exception != null)
            {
                Trace.WriteLine(FormatLine("ERROR", filePath, memberName, lineNumber, exception.Message));

                if (exception.StackTrace != null)
                {
                    Trace.WriteLine(FormatLine("ERROR", filePath, memberName, lineNumber, exception.StackTrace,
                        new object[] {}));
                }
            }
        }

        private string FormatCallerFilePath(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        private string FormatLine(string level, string filePath, string memberName, int lineNumber, string message, object[] args = null)
        {
            string levelLabel = string.IsNullOrEmpty(level) ? "" : level + ": ";
            if (args == null) args = new object[] {};
            return string.Format("{0}Logger({1})\t{2}.{3}(),{4}\t{5}", levelLabel, Key, FormatCallerFilePath(filePath), memberName, lineNumber,
                string.Format(message, args));
        }
    }
}
