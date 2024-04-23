using System.Collections.Generic;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Represents the data in XPT document
    /// </summary>
    public sealed class SasXptDataRecord : ISasXptElement
    {
        /// <summary>
        /// A collection with all parsed XPT variables form the document
        /// </summary>
        public IEnumerable<SasXptVariable> Variables { get; init; }

        /// <summary>
        /// A collection with all parsed XPT observations form the document
        /// </summary>
        public IEnumerable<SasXptObservation> Observations { get; init; }
    }
}