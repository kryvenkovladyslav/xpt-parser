namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides required bytes for reading elements of XPT Member Descriptor Record
    /// </summary>
    public static class SasXptMemberDescriptorRecordBytesDescriber
    {
        /// <summary>
        /// Represents required bytes for reading a header
        /// </summary>
        public static byte Header { get; } = 80;

        /// <summary>
        /// Represents required bytes for reading a descriptor header
        /// </summary>
        public static byte Descriptor { get; } = 80;

        /// <summary>
        /// Represents required bytes for reading a SAS symbol
        /// </summary>
        public static byte Symbol { get; } = 8;

        /// <summary>
        /// Represents required bytes for reading a name of dataset
        /// </summary>
        public static byte DataSetName { get; } = 8;

        /// <summary>
        /// Represents required bytes for reading a SAS dataset
        /// </summary>
        public static byte DataSet { get; } = 8;

        /// <summary>
        /// Represents required bytes for reading a SAS version
        /// </summary>
        public static byte Version { get; } = 8;

        /// <summary>
        /// Represents required bytes for reading a operating system
        /// </summary>
        public static byte OperationSystem { get; } = 8;

        /// <summary>
        /// Represents blanks bytes between operation system and creational date 
        /// </summary>
        public static byte Blanks { get; } = 24;

        /// <summary>
        /// Represents required bytes for reading a creational date 
        /// </summary>
        public static byte CreatedDateTime { get; } = 16;

        /// <summary>
        /// Represents required bytes for reading a modified date 
        /// </summary>
        public static byte ModifiedDateTime { get; } = 32;

        /// <summary>
        /// Represents required bytes for reading a SAS label
        /// </summary>
        public static byte Label { get; } = 48;
    }
}