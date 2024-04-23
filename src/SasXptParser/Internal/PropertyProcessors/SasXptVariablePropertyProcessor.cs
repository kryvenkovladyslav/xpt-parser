using SasXptParser.Abstract;
using System;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides methods for processing parsing object properties
    /// </summary>
    internal abstract class SasXptVariablePropertyProcessor : ISasXptElementObjectPropertyProcessor
    {
        /// <summary>
        /// Holds parsing pairs for each element of the XPT variable record
        /// </summary>
        protected internal SasXptVariableRecordBytes ParsingBytes { get; private init; } = new();

        /// <summary>
        /// Process object properties 
        /// </summary>
        /// <param name="propertyName">A name of the property will be processed</param>
        /// <param name="byteProcessor">A processor for parsing the value of the property</param>
        /// <param name="bytes">Arrays of bytes will be parsed</param>
        /// <returns>Parsed property value</returns>
        public abstract object ProcessProperty(string propertyName, ISasXptByteProcessor byteProcessor, byte[] bytes);
    }
}