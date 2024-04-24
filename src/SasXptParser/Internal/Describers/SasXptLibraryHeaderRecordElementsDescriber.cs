namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides names of parsed .NET LibraryHeaderRecord object
    /// </summary>
    internal static class SasXptLibraryHeaderRecordElementsDescriber
    {
        /// <summary>
        /// Represents a name of the version property for parsing
        /// </summary>
        public static string Version { get; } = nameof(Version);

        /// <summary>
        /// Represents a name of the operation system property for parsing
        /// </summary>
        public static string OperationSystem { get; } = nameof(OperationSystem);

        /// <summary>
        /// Represents a name of the creational date property for parsing
        /// </summary>
        public static string CreatedDateTime { get; } = nameof(CreatedDateTime);

        /// <summary>
        /// Represents a name of the last modified date property for parsing
        /// </summary>
        public static string LastModifiedDateTime { get; } = nameof(LastModifiedDateTime);
    }
}