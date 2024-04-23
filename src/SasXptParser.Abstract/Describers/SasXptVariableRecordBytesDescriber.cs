namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides required bytes for reading elements of XPT Variable records
    /// </summary>
    public static class SasXptVariableRecordBytesDescriber
    {
        /// <summary>
        /// Represents required bytes for reading a name of the variable
        /// </summary>
        public static byte Name { get; } = 8;

        /// <summary>
        /// Represents required bytes for reading a label of the variable
        /// </summary>
        public static byte Label { get; } = 24;

        /// <summary>
        /// Represents required bytes for reading a length of the variable
        /// </summary>
        public static byte Length { get; } = 2;

        /// <summary>
        /// Represents required bytes for reading a position of the variable
        /// </summary>
        public static byte Position { get; } = 4;
    }
}