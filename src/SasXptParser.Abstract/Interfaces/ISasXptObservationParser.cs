using System.Collections.Generic;
using System.IO;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides methods for parsing XPT variable records
    /// </summary>
    public interface ISasXptObservationParser
    {
        /// <summary>
        /// Parses XPT variable records of XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <param name="variables">A collection of parsed XPT variables</param>
        /// <returns>Parsed collection of XPT observation against the parser</returns>
        public IEnumerable<SasXptObservation> ParseObservations(Stream sasXptDocumentStream, IEnumerable<SasXptVariable> variables);
    }
}