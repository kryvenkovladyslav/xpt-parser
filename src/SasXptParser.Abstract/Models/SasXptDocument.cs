namespace SasXptParser.Abstract
{
    /// <summary>
    /// Represents a parsed XPT document divided into different parts 
    /// </summary>
    public sealed class SasXptDocument
    {
        /// <summary>
        /// Represents XPT parsed Library Header Record from XPT document
        /// </summary>
        public SasXptLibraryHeaderRecord LibraryHeaderRecord { get; init; }

        /// <summary>
        /// Represents XPT parsed Member Descriptor Header Record from XPT document
        /// </summary>
        public SasXptMemberDescriptorHeaderRecord MemberDescriptorRecord { get; init; }

        /// <summary>
        /// Represents XPT parsed Data Record from XPT document
        /// </summary>
        public SasXptDataRecord DataRecord { get; init; }
    }
}