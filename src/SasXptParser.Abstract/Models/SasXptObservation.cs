using System.Collections.Generic;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Represents a current observation record specified in XPT document 
    /// </summary>
    /// <param name="Value"></param>
    public sealed record SasXptObservationRow(string Value);

    /// <summary>
    /// Represents a parsed observation from XPT document 
    /// </summary>
    public sealed class SasXptObservation : ISasXptElement
    {
        /// <summary>
        /// Represents a parsed observation row from XPT document
        /// </summary>
        public List<SasXptObservationRow> Rows { get; init; } = new();
    }
}