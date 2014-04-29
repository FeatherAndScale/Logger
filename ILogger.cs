using System;
using System.Runtime.CompilerServices;

namespace Scale.Logger
{
    /// <summary>
    /// Logger object for writing messages to a log.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// The Key that identifies this instance of Logger.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Logs a message. message can be a format string with optional args.
        /// </summary>
        void Message(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs an information message. message can be a format string with optional args.
        /// </summary>
        void Info(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs an error message. message can be a format string with optional args.
        /// </summary>
        void Error(string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs an Exception stack trace.
        /// </summary>
        void Error(Exception exception, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs an error message and Exception stack trace. message can be a format string with optional args.
        /// </summary>
        void Error(Exception exception, string message, object[] args = null, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "",
            [CallerLineNumber] int lineNumber = 0);
    }
}
