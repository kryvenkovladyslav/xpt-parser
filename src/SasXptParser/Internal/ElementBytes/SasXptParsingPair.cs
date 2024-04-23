namespace SasXptParser.Internal
{
    /// <summary>
    /// Represents a pair for reading an element from XPT document
    /// </summary>
    public readonly struct SasXptParsingPair
    {
        /// <summary>
        /// Represents a count of bytes is needed to be skipped 
        /// </summary>
        public int SkipCount { get; init; }

        /// <summary>
        /// Represents a count of bytes is needed to be read
        /// </summary>
        public int ReadableCount { get; init; }
    }
}