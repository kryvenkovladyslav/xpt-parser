namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides names of parsed .NET Variable object
    /// </summary>
    internal static class SasXptVariableElementsDescriber
    {
        // <summary>
        /// Represents a name of the variable for parsing
        /// </summary>
        public static string Name { get; } = nameof(Name);

         // <summary>
        /// Represents a label of the variable for parsing
        /// </summary>
        public static string Label { get; } = nameof(Label);

        // <summary>
        /// Represents a length of the variable for parsing
        /// </summary>
        public static string Length { get; } = nameof(Length);

        // <summary>
        /// Represents a position of the variable for parsing
        /// </summary>
        public static string Position { get; } = nameof(Position);

        // <summary>
        /// Represents a label type the variable for parsing
        /// </summary>
        public static string VariableType { get; } = nameof(VariableType);
    }
}