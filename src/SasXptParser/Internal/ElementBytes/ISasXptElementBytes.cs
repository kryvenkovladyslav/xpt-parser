namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides method for getting appropriate parsing pair for the element
    /// </summary>
    public interface ISasXptElementBytes
    {
        /// <summary>
        /// Extracts required parsing pair for the key 
        /// </summary>
        /// <param name="key">Provides a name of the element is need to be read</param>
        /// <returns>Extracted parsing pair</returns>
        public SasXptParsingPair GetParsingPairByKey(string key);
    }
}