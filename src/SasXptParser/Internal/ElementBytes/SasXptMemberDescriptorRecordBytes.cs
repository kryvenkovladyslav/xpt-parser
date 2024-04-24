using SasXptParser.Abstract;
using System.Collections.Concurrent;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Represents a collection for getting required bytes for th element
    /// </summary>
    public readonly struct SasXptMemberDescriptorRecordBytes : ISasXptElementBytes
    {
        /// <summary>
        /// Holds bytes for the XPT element 
        /// </summary>
        private readonly ConcurrentDictionary<string, SasXptParsingPair> bytes;

        /// <summary>
        /// Creates the instance initializing the collection
        /// </summary>
        public SasXptMemberDescriptorRecordBytes()
        {
            this.bytes = new ConcurrentDictionary<string, SasXptParsingPair>();

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.DataSetName, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.DataSetName,
                SkipCount = SasXptMemberDescriptorRecordBytesDescriber.Descriptor + SasXptMemberDescriptorRecordBytesDescriber.Symbol
            });

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.DataSet, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.DataSet,
                SkipCount = default(int)
            });

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.Version, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.Version,
                SkipCount = default(int)
            });

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.OperationSystem, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.OperationSystem,
                SkipCount = default(int)
            });

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.CreatedDateTime, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.CreatedDateTime,
                SkipCount = SasXptMemberDescriptorRecordBytesDescriber.Blanks
            });

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.ModifiedDateTime, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.ModifiedDateTime,
                SkipCount = default(int)
            });

            this.bytes.TryAdd(SasXptMemberDescriptorRecordElementsDescriber.Label, new SasXptParsingPair
            {
                ReadableCount = SasXptMemberDescriptorRecordBytesDescriber.Label,
                SkipCount = default(int)
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