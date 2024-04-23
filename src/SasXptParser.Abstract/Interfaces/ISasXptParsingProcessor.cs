using System.IO;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides methods for processing the XPT document
    /// </summary>
    public interface ISasXptParsingProcessor
    {
        /// <summary>
        /// Parses the entire XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <returns>Parsed XPT document</returns>
        public SasXptDocument ParseDocument(Stream sasXptDocumentStream);
    }
}