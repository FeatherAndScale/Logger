using System;
using System.IO;
using System.Runtime.CompilerServices;
using Common.Logging;

namespace Scale.Logger
{
    /// <summary>
    /// Logger object for writing log messages to the system Trace listener.
    /// </summary>
    public class TraceLogger : ILogger
    {
        private readonly ILog _commonLog;

        public TraceLogger(string key, ILog commonLog)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            if (commonLog == null) throw new ArgumentNullException("commonLog");            
            
            Key = key;
            _commonLog = commonLog;
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
            _commonLog.Trace(FormatLine(filePath, memberName, lineNumber, message, args));
        }

        /// <summary>
        /// Logs an information message. message can be a format string with optional args.
        /// </summary>
        public void Info(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            _commonLog.Info(FormatLine(filePath, memberName, lineNumber, message, args));
        }

        /// <summary>
        /// Logs an error message. message can be a format string with optional args.
        /// </summary>
        public void Error(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            _commonLog.Error(FormatLine(filePath, memberName, lineNumber, message, args));
        }

        /// <summary>
        /// Logs an Exception stack trace.
        /// </summary>
        public void Error(Exception exception, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string message = exception == null ? "(Exception is null)" : exception.Message;
            _commonLog.Error(FormatLine(filePath, memberName, lineNumber, message), exception);
        }

        /// <summary>
        /// Logs an error message and Exception stack trace. message can be a format string with optional args.
        /// </summary>
        public void Error(Exception exception, string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            _commonLog.Error(FormatLine(filePath, memberName, lineNumber, message, args), exception);
        }

        private string FormatCallerFilePath(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        private string FormatLine(string filePath, string memberName, int lineNumber, string message, object[] args = null)
        {
            if (args == null) args = new object[] {};
            return string.Format("{0}.{1}(),{2}\t{3}", FormatCallerFilePath(filePath), memberName, lineNumber,
                string.Format(message, args));
        }
    }
}
