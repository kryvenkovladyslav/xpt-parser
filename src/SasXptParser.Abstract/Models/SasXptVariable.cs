namespace SasXptParser.Abstract
{
    public sealed class SasXptVariable : ISasXptElement
    {
        /// <summary>
        /// Represent a parsed name of variable specified in XPT document
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Represent a parsed label of variable specified in XPT document
        /// </summary>
        public string Label { get; init; }

        /// <summary>
        /// Represent a parsed variable length
        /// </summary>
        public int Length { get; init; }

        /// <summary>
        /// Represent a parsed position of variable
        /// </summary>
        public int Position { get; init; }

        /// <summary>
        /// Represent a parsed type of the variable specified in XPT document
        /// </summary>
        public SasXptVariableTypes VariableType { get; init; }
    }
}