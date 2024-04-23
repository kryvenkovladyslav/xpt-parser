using System.Collections.Generic;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides methods for extracting a required property processor
    /// </summary>
    internal class SasXptVariablePropertyProcessorProvider : ISasXptPropertyProcessorProvider
    {
        /// <summary>
        /// Holds all required processors for parging variable properties
        /// </summary>
        private readonly Dictionary<string, SasXptVariablePropertyProcessor> processors;

        /// <summary>
        /// Initializes the instance
        /// </summary>
        public SasXptVariablePropertyProcessorProvider()
        {
            this.processors = new()
            {
                { SasXptVariableElementsDescriber.Name, new SasXptVariableNamePropertyProcessor() },
                { SasXptVariableElementsDescriber.Label, new SasXptVariableLabelPropertyProcessor() },
                { SasXptVariableElementsDescriber.Length, new SasXptVariableLengthPropertyProcessor() },
                { SasXptVariableElementsDescriber.Position, new SasXptVariablePositionPropertyProcessor() },
                { SasXptVariableElementsDescriber.VariableType, new SasXptVariableVariableTypePropertyProcessor() }
            };
        }

        /// <summary>
        /// Extracts a required property processor using a key
        /// </summary>
        /// <param name="key">A name of the property will be processed</param>
        /// <returns>Required property processor</returns>
        public SasXptVariablePropertyProcessor GetRequiredProcessor(string key)
        {
            return this.processors[key];
        }
    }
}