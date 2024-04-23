using System.Collections.Generic;
using System.IO;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides methods for parsing XPT variable records
    /// </summary>
    public interface ISasXptVariableParser
    {
        /// <summary>
        /// Parses XPT variable records of XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <returns>Parsed collection of XPT variables against the parser</returns>
        public IEnumerable<SasXptVariable> ParseVariables(Stream sasXptDocumentStream);
    }
}