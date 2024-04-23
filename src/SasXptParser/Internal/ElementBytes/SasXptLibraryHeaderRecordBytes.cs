using SasXptParser.Abstract;
using System.Collections.Concurrent;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Represents a collection for getting required bytes for th element
    /// </summary>
    public readonly struct SasXptLibraryHeaderRecordBytes : ISasXptElementBytes
    {
        /// <summary>
        /// Holds bytes for the XPT element 
        /// </summary>
        private readonly ConcurrentDictionary<string, SasXptParsingPair> bytes;

        /// <summary>
        /// Creates the instance initializing the collection
        /// </summary>
        public SasXptLibraryHeaderRecordBytes()
        {
            this.bytes = new ConcurrentDictionary<string, SasXptParsingPair>();

            this.bytes.TryAdd(SasXptLibraryHeaderRecordElementsDescriber.Version, new SasXptParsingPair
            {
                ReadableCount = SasXptLibraryHeaderRecordBytesDescriber.Version,
                SkipCount = 2 * SasXptLibraryHeaderRecordBytesDescriber.Symbol + SasXptLibraryHeaderRecordBytesDescriber.Library
            });

            this.bytes.TryAdd(SasXptLibraryHeaderRecordElementsDescriber.OperationSystem, new SasXptParsingPair
            {
                ReadableCount = SasXptLibraryHeaderRecordBytesDescriber.OperationSystem,
                SkipCount = default
            });

            this.bytes.TryAdd(SasXptLibraryHeaderRecordElementsDescriber.CreatedDateTime, new SasXptParsingPair
            {
                ReadableCount = SasXptLibraryHeaderRecordBytesDescriber.DateTime,
                SkipCount = SasXptLibraryHeaderRecordBytesDescriber.Blanks
            });

            this.bytes.TryAdd(SasXptLibraryHeaderRecordElementsDescriber.LastModifiedDateTime, new SasXptParsingPair
            {
                ReadableCount = SasXptLibraryHeaderRecordBytesDescriber.Header,
                SkipCount = default
            });
        }

        /// <summary>
        /// Extracts required parsing pair for the key 
        /// </summary>
        /// <param name="key">Provides a name of the element is need to be read</param>
        /// <returns>Extracted parsing pair</returns>
        public SasXptParsingPair GetParsingPairByKey(string key)
        {
            this.bytes.TryGetValue(key, out SasXptParsingPair value);
            return value;
        }
    }
}