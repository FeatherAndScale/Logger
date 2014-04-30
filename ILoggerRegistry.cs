namespace Scale.Logger
{
    /// <summary>
    /// A registry for instances of Logger.
    /// </summary>
    public interface ILoggerRegistry
    {
        /// <summary>
        /// Gets an ILogger named by key.
        /// </summary>
        /// <param name="key">A key that identifies this Logger. <see cref="MakeKey"/></param>
        /// <returns>An instance of an ILogger</returns>
        ILogger Logger(string key);

        /// <summary>
        /// Helper to make a key from a list of Ids in a format similar to aaa.bbb.ccc.
        /// </summary>
        /// <param name="ids">A param array of ids to use to create the Key.</param>
        /// <returns>A Key as string</returns>
        string MakeKey(params object[] ids);
    }
}
