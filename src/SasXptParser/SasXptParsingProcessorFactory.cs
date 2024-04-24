using SasXptParser.Abstract;
using SasXptParser.Internal;

namespace SasXptParser
{
    /// <summary>
    /// Provides methods for creating a processor for parsing XPT document
    /// </summary>
    public sealed class SasXptParsingProcessorFactory
    {
        /// <summary>
        /// Creates a parsing processor with all required dependencies for parsing XPT documents
        /// </summary>
        /// <returns>Created parsing processor</returns>
        public ISasXptParsingProcessor CreateParsingProcessor()
        {
            var byteProcessor = new SasXptByteProcessor();
            var sasXptVariablePropertyProcessorProvider = new SasXptVariablePropertyProcessorProvider();
            var sasXptVariablesParser = new SasXptVariableParser(byteProcessor, sasXptVariablePropertyProcessorProvider);
            var sasXptObservationsParser = new SasXptObservationsParser(byteProcessor);
            var sasXptLibraryHeaderRecordParser = new SasXptLibraryHeaderRecordParser(byteProcessor);
            var sasXptMemberDescriptorHeaderRecordParser = new SasXptMemberDescriptorHeaderRecordParser(byteProcessor);
            var sasXptDataRecordParser = new SasXptDataRecordParser(sasXptVariablesParser, sasXptObservationsParser);

            return new SasXptParsingProcessor(new ISasXptParser<ISasXptElement>[]
            {
                sasXptLibraryHeaderRecordParser,
                sasXptMemberDescriptorHeaderRecordParser,
                sasXptDataRecordParser
            });
        }
    }
}