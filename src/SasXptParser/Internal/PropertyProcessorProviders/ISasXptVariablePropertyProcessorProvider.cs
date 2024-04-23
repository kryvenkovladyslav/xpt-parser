namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides methods for extracting a required property processor
    /// </summary>
    internal interface ISasXptPropertyProcessorProvider
    {
        /// <summary>
        /// Extracts a required property processor using a key
        /// </summary>
        /// <param name="key">A name of the property will be processed</param>
        /// <returns>Required property processor</returns>
        public SasXptVariablePropertyProcessor GetRequiredProcessor(string key);
    }
}