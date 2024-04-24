using SasXptParser.Abstract;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides methods for processing parsing object properties
    /// </summary>
    internal interface ISasXptElementObjectPropertyProcessor
    {
        /// <summary>
        /// Process object properties 
        /// </summary>
        /// <param name="propertyName">A name of the property will be processed</param>
        /// <param name="byteProcessor">A processor for parsing the value of the property</param>
        /// <param name="bytes">Arrays of bytes will be parsed</param>
        /// <returns>Parsed property value</returns>
        public object ProcessProperty(string propertyName, ISasXptByteProcessor byteProcessor, byte[] bytes);
    }
}