namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides methods for creating a processor for parsing XPT document
    /// </summary>
    public interface ISasXptParsingProcessorFactory
    {
        /// <summary>
        /// Creates a parsing processor with all required dependencies for parsing XPT documents
        /// </summary>
        /// <returns>Created parsing processor</returns>
        public ISasXptParsingProcessor CreateParsingProcessor();
    }
}