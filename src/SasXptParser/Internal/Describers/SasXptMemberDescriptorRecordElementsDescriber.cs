namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides names of parsed .NET MemberDescriptorRecord object
    /// </summary>
    internal static class SasXptMemberDescriptorRecordElementsDescriber
    {
        // <summary>
        /// Represents a name of the dataset name for parsing
        /// </summary>
        public static string DataSetName { get; } = nameof(DataSetName);

        // <summary>
        /// Represents a name of the dataset property for parsing
        /// </summary>
        public static string DataSet { get; } = nameof(DataSet);

        // <summary>
        /// Represents a name of the version property for parsing
        /// </summary>
        public static string Version { get; } = nameof(Version);

        /// <summary>
        /// Represents a name of the operation creational date property for parsing
        /// </summary>
        public static string OperationSystem { get; } = nameof(OperationSystem);

        /// <summary>
        /// Represents a name of the creational date property for parsing
        /// </summary>
        public static string CreatedDateTime { get; } = nameof(CreatedDateTime);

        /// <summary>
        /// Represents a name of the last modified date property for parsing
        /// </summary>
        public static string ModifiedDateTime { get; } = nameof(ModifiedDateTime);

        /// <summary>
        /// Represents a name of the label property for parsing
        /// </summary>
        public static string Label { get; } = nameof(Label);
    }
}