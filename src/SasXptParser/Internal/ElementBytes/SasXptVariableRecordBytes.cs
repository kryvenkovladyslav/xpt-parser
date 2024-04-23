using SasXptParser.Abstract;
using System.Collections.Concurrent;

namespace SasXptParser.Internal
{
    internal struct SasXptVariableRecordBytes : ISasXptElementBytes
    {
        /// <summary>
        /// Holds bytes for the XPT element 
        /// </summary>
        private readonly ConcurrentDictionary<string, SasXptParsingPair> bytes;

        /// <summary>
        /// Creates the instance initializing the collection
        /// </summary>
        public SasXptVariableRecordBytes()
        {
            this.bytes = new ConcurrentDictionary<string, SasXptParsingPair>();

            this.bytes.TryAdd(SasXptVariableElementsDescriber.Name, new SasXptParsingPair
            {
                ReadableCount = SasXptVariableRecordBytesDescriber.Name,
                SkipCount = SasXptVariableRecordBytesDescriber.Name
            });

            this.bytes.TryAdd(SasXptVariableElementsDescriber.Label, new SasXptParsingPair
            {
                ReadableCount = 2 * SasXptVariableRecordBytesDescriber.Name + SasXptVariableRecordBytesDescriber.Label,
                SkipCount = 2 * SasXptVariableRecordBytesDescriber.Name
            });

            this.bytes.TryAdd(SasXptVariableElementsDescriber.Length, new SasXptParsingPair
            {
                ReadableCount = SasXptVariableRecordBytesDescriber.Length,
                SkipCount = 2 * SasXptVariableRecordBytesDescriber.Length
            });

            this.bytes.TryAdd(SasXptVariableElementsDescriber.Position, new SasXptParsingPair
            {
                ReadableCount = SasXptVariableRecordBytesDescriber.Position,
                SkipCount = SasXptElementLengthDescriber.HeaderRecordByteLength + SasXptVariableRecordBytesDescriber.Position
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