using System;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Represents a parsed Library Header Record from XPT document
    /// </summary>
    public sealed class SasXptLibraryHeaderRecord : ISasXptHeaderRecord
    {
        /// <summary>
        /// Represent a parsed version value specified in XPT document
        /// </summary>
        public string Version { get; init; }

        /// <summary>
        /// Represent a parsed operation system value specified in XPT document
        /// </summary>
        public string OperationSystem { get; init; }

        /// <summary>
        /// Represent a parsed creational date and time specified in XPT document
        /// </summary>
        public DateTime CreatedDateTime { get; init; }

        /// <summary>
        /// Represent a parsed last modified date and time specified in XPT document
        /// </summary>
        public DateTime LastModifiedDateTime { get; init; }
    }
}