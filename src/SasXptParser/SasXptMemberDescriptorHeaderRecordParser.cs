using SasXptParser.Abstract;
using SasXptParser.Internal;
using System.IO;

namespace SasXptParser
{
    /// <summary>
    /// Provides methods for parsing XPT Member Descriptor Header Record into .NET object
    /// </summary>
    public class SasXptMemberDescriptorHeaderRecordParser : SasXptHeaderRecordParser<SasXptMemberDescriptorHeaderRecord>, ISasXptParser<SasXptMemberDescriptorHeaderRecord>
    {
        /// <summary>
        /// Initializes the instance using ISasXptByteProcessor
        /// </summary>
        /// <param name="byteProcessor">Provided ISasXptByteProcessor</param>
        public SasXptMemberDescriptorHeaderRecordParser(ISasXptByteProcessor byteProcessor) : base(byteProcessor, new SasXptMemberDescriptorRecordBytes())
        { }

        /// <summary>
        /// Parses the required XPT record of the document into specified .NET object
        /// </summary>
        /// <param name="sasXptDocumentStream"></param>
        /// <returns>Parsed XPT header into .NET object</returns>
        public virtual SasXptMemberDescriptorHeaderRecord ParseElement(Stream sasXptDocumentStream)
        {
            return this.ParseHeaderRecord(sasXptDocumentStream);
        }

        /// <summary>
        /// Provides header record of the XPT document for parsing 
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        /// <returns>Extracted current header of the XPT document</returns>
        protected virtual string GetCurrentHeaderRecord(Stream sasXptDocumentStream)
        {
            var headerElementBytes = this.GetBytesFromStream(sasXptDocumentStream, SasXptMemberDescriptorRecordBytesDescriber.Header);
            return this.ByteProcessor.ConvertBytesToString(headerElementBytes);
        }

        /// <summary>
        /// Setups the required stream position for parsing the required part of the XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        protected override void SetupRequiredStreamPosition(Stream sasXptDocumentStream)
        {
            sasXptDocumentStream.Position = SasXptPositionDescriber.MemberDescriptorRecordDefaultPosition;
        }

        /// <summary>
        /// Throws the exception if the header does not satisfy the required header
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        protected override void ThrowIfInvalidHeader(Stream sasXptDocumentStream)
        {
            var providedHeaderRecord = this.GetCurrentHeaderRecord(sasXptDocumentStream);
            SasXptInvalidHeaderRecordException.ThrowIfInvalidHeaderRecord(providedHeaderRecord, SasXptHeaderRecordDescriber.SasXptMemberDescriptor);
        }
    }
}