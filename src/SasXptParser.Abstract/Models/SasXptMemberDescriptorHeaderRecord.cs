using System;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Represents a parsed Member Descriptor Header Record from XPT document
    /// </summary>
    public sealed class SasXptMemberDescriptorHeaderRecord : ISasXptHeaderRecord
    {
        /// <summary>
        /// Represent a parsed dataSet name value specified in XPT document
        /// </summary>
        public string DataSetName { get; init; }

        /// <summary>
        /// Represent a parsed dataSet  value specified in XPT document
        /// </summary>
        public string DataSet { get; init; }

        /// <summary>
        /// Represent a parsed version value specified in XPT document
        /// </summary>
        public string Version { get; init; }

        /// <summary>
        /// Represent a parsed operation system value specified in XPT document
        /// </summary>
        public string OperationSystem { get; init; }

        /// <summary>
        /// Represent a parsed created date and time specified in XPT document
        /// </summary>
        public DateTime CreatedDateTime { get; init; }

        /// <summary>
        /// Represent a parsed created date and time specified in XPT document
        /// </summary>
        public DateTime ModifiedDateTime { get; init; }

        /// <summary>
        /// Represent a parsed label value specified in XPT document
        /// </summary>
        public string Label { get; init; }
    }
}