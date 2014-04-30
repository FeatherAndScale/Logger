using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Scale.Logger
{
    /// <summary>
    /// A registry for instances of Logger.
    /// </summary>
    public class LoggerRegistry : ILoggerRegistry
    {
        private readonly IDictionary<string, ILogger> _instances = new ConcurrentDictionary<string, ILogger>();

        /// <summary>
        /// Gets an ILogger named by key.
        /// </summary>
        /// <param name="key">A key that identifies this Logger. <see cref="MakeKey"/></param>
        /// <returns>An instance of an ILogger</returns>
        public ILogger Logger(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            ILogger value;
            if (_instances.TryGetValue(key, out value)) return value;

            var logger = new TraceLogger(key);
            _instances.Add(key, logger);

            return logger;
        }

        /// <summary>
        /// Helper to make a key from a list of Ids in a format similar to aaa.bbb.ccc.
        /// </summary>
        /// <param name="ids">A param array of ids to use to create the Key.</param>
        /// <returns>A Key as string</returns>
        public string MakeKey(params object[] ids)
        {
            if (ids == null) throw new ArgumentNullException("ids");
            var builder = new StringBuilder();
            for (int i = 0; i < ids.Length; i++)
            {
                if (i > 0) builder.Append(".");
                builder.Append(ids[i]);
            }
            return builder.ToString();
        }
    }
}
