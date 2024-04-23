using SasXptParser.Abstract;
using SasXptParser.Internal;
using System;
using System.IO;

namespace SasXptParser
{
    /// <summary>
    /// Provides method for parsing XPT Header Elements into .NET objects
    /// </summary>
    /// <typeparam name="TSasXptHeader">Represents XPT header record</typeparam>
    public abstract class SasXptHeaderRecordParser<TSasXptHeader> where TSasXptHeader : ISasXptHeaderRecord
    {
        /// <summary>
        /// Provides methods for dealing with array of bytes
        /// </summary>
        protected internal ISasXptByteProcessor ByteProcessor { get; private init; }

        /// <summary>
        /// Provides bytes for parsing current element
        /// </summary>
        protected internal ISasXptElementBytes ParsingBytes { get; private init; }

        /// <summary>
        /// Initializes the instance using ISasXptByteProcessor
        /// </summary>
        internal SasXptHeaderRecordParser(ISasXptByteProcessor byteProcessor, ISasXptElementBytes parsingBytes)
        {
            this.ParsingBytes = parsingBytes;
            this.ByteProcessor = byteProcessor ?? throw new ArgumentNullException(nameof(byteProcessor));
        }

        /// <summary>
        /// Parses the required XPT record of the document into specified .NET object
        /// </summary>
        /// <param name="sasXptDocumentStream"></param>
        /// <returns>Parsed XPT header into .NET object</returns>
        internal virtual TSasXptHeader ParseHeaderRecord(Stream sasXptDocumentStream)
        {
            this.ThrowIfNull(sasXptDocumentStream);
            this.SetupRequiredStreamPosition(sasXptDocumentStream);
            this.ThrowIfInvalidHeader(sasXptDocumentStream);

            var sasXptElement = Activator.CreateInstance<TSasXptHeader>();
            var properties = sasXptElement.GetType().GetProperties();

            Array.ForEach(properties, property =>
            {
                var parsingPair = this.ParsingBytes.GetParsingPairByKey(property.Name);
                sasXptDocumentStream.Position += parsingPair.SkipCount;
                var recordElementBytes = this.GetBytesFromStream(sasXptDocumentStream, parsingPair.ReadableCount);
                property.SetValue(sasXptElement, this.ConvertToType(property.PropertyType, recordElementBytes));
            });

            return sasXptElement;
        }

        /// <summary>
        /// Converts array of bytes into required type
        /// </summary>
        /// <param name="requiredType">Required type for array of bytes will be converted</param>
        /// <param name="bytesToConvert">Array with read bytes</param>
        /// <returns>The converted object of required type</returns>
        protected internal virtual object ConvertToType(Type requiredType, byte[] bytesToConvert)
        {
            return requiredType == typeof(string) ? this.ByteProcessor.ConvertBytesToString(bytesToConvert) :
                this.ByteProcessor.ConvertBytesToDateTime(bytesToConvert);
        }

        /// <summary>
        /// Gets bytes from the Stream
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing the XPT document</param>
        /// <param name="parsingBytesCount">Required count of bytes to be read</param>
        /// <param name="offset">The required offset</param>
        /// <returns>New array of read bytes</returns>
        protected internal byte[] GetBytesFromStream(Stream sasXptDocumentStream, int parsingBytesCount, int offset = default(int))
        {
            var buffer = new byte[parsingBytesCount];
            sasXptDocumentStream.Read(buffer, offset, parsingBytesCount);
            return buffer;
        }

        /// <summary>
        /// Throws the ArgumentNullException if the entire stream in null
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing the XPT document</param>
        protected void ThrowIfNull(Stream sasXptDocumentStream)
        {
            ArgumentNullException.ThrowIfNull(sasXptDocumentStream, nameof(sasXptDocumentStream));
        }

        /// <summary>
        /// Setups the required stream position for parsing the required part of the XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        protected abstract void SetupRequiredStreamPosition(Stream sasXptDocumentStream);

        /// <summary>
        /// Throws the exception if the header does not satisfy the required header
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        protected abstract void ThrowIfInvalidHeader(Stream sasXptDocumentStream);
    }
}