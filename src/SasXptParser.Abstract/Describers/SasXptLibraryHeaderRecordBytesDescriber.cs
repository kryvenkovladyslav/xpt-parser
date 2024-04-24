namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides required bytes for reading elements of XPT Library Header record
    /// </summary>
    public static class SasXptLibraryHeaderRecordBytesDescriber
    {
        /// <summary>
        /// Represents required bytes for reading a header
        /// </summary>
        public static byte Header { get; } = 80;

        /// <summary>
        /// Represents required bytes for reading a SAS symbol
        /// </summary>
        public static byte Symbol { get; } = 8;

        /// <summary>
        /// Represents required bytes for reading a SAS library
        /// </summary>
        public static byte Library { get; } = 8;

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
        public static byte DateTime { get; } = 16;
    }
}