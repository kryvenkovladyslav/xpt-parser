using SasXptParser.Abstract;

namespace SasXptParser.Internal
{
    internal class SasXptVariableVariableTypePropertyProcessor : SasXptVariablePropertyProcessor
    {
        /// <summary>
        /// Process object properties 
        /// </summary>
        /// <param name="propertyName">A name of the property will be processed</param>
        /// <param name="byteProcessor">A processor for parsing the value of the property</param>
        /// <param name="bytes">Arrays of bytes will be parsed</param>
        /// <returns>Parsed property value</returns>
        public override object ProcessProperty(string propertyName, ISasXptByteProcessor byteProcessor, byte[] bytes)
        {
            var value = byteProcessor.ConvertToBigEndian(byteProcessor.ConvertBytesToShort(bytes));
            return value == 1 ? SasXptVariableTypes.Number : SasXptVariableTypes.Character;
        }
    }
}