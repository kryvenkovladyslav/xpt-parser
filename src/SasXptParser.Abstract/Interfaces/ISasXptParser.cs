using System.IO;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides methods for parsing XPT element into .NET objects
    /// </summary>
    /// <typeparam name="TSasXptElement">The element is required to be parsed</typeparam>
    public interface ISasXptParser<out TSasXptElement> where TSasXptElement : ISasXptElement
    {
        /// <summary>
        /// Parses the specified XPT element into .NET object
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <returns>Parsed XPT element against the parser</returns>
        public TSasXptElement ParseElement(Stream sasXptDocumentStream);
    }
}