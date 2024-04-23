﻿using SasXptParser.Abstract;

namespace SasXptParser.Internal
{
    internal class SasXptVariableNamePropertyProcessor : SasXptVariablePropertyProcessor
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
            var parsingPair = this.ParsingBytes.GetParsingPairByKey(propertyName);
            var nameByteSubset = byteProcessor.GetSubsetFromByteArray(bytes, parsingPair.SkipCount, parsingPair.ReadableCount);
            return byteProcessor.ConvertBytesToString(nameByteSubset);
        }
    }
}