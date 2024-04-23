using SasXptParser.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides methods for parsing XPT observation records into .NET objects
    /// </summary>
    internal sealed class SasXptVariableParser : ISasXptVariableParser
    {
        /// <summary>
        /// Provides methods for dealing with array of bytes
        /// </summary>
        private readonly ISasXptByteProcessor byteProcessor;

        private readonly ISasXptPropertyProcessorProvider processorProvider;

        /// <summary>
        /// Initializes the instance using ISasXptByteProcessor 
        /// </summary>
        /// <param name="byteProcessor">The instance of ISasXptByteProcessor</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException is thrown if instance is not provided</exception>
        public SasXptVariableParser(ISasXptByteProcessor byteProcessor, ISasXptPropertyProcessorProvider processorProvider)
        {
            this.byteProcessor = byteProcessor ?? throw new ArgumentNullException(nameof(byteProcessor));
            this.processorProvider = processorProvider ?? throw new ArgumentNullException(nameof(processorProvider));
        }

        /// <summary>
        /// Parses variables records of the XPT document into .NET objects
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <param name="variables">Parsed XPT variables</param>
        /// <returns>A collection of parsed variables from provided XPT document</returns>
        public IEnumerable<SasXptVariable> ParseVariables(Stream sasXptDocumentStream)
        {
            this.SetupDocumentConfiguration(sasXptDocumentStream);
            var buffer = ReadNextXptRecord(sasXptDocumentStream, SasXptElementLengthDescriber.HeaderRecordByteLength);
            var parsedHeader = GetStringFromParsedBytes(buffer);
            this.ThrowIfInvalidHeader(parsedHeader);

            var variables = new List<SasXptVariable>();

            for (var index = 0; index < this.GetVariableNumbersFromHeader(parsedHeader); index++)
                variables.Add(this.ParseVariableRecord(sasXptDocumentStream));

            return variables;
        }

        /// <summary>
        /// Parses a XPT single variable record into .NET object
        /// </summary>
        /// <param name="documentStream">The stream representing XPT document</param>
        /// <returns>Parsed XPT variable</returns>
        private SasXptVariable ParseVariableRecord(Stream documentStream)
        {
            var bytesToConvert = this.ReadNextXptRecord(documentStream, SasXptElementLengthDescriber.ObservationRecordByteLength);

            var parsedVariable = new SasXptVariable();

            var properties = parsedVariable.GetType().GetProperties();

            foreach (var property in properties)
            {
                var processor = this.processorProvider.GetRequiredProcessor(property.Name);
                property.SetValue(parsedVariable, processor.ProcessProperty(property.Name, this.byteProcessor, bytesToConvert));
            }

            return parsedVariable;
        }

        /// <summary>
        /// Setups the required stream position for parsing the required part of the XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        private void SetupDocumentConfiguration(Stream sasXptDocumentStream)
        {
            sasXptDocumentStream.Position = SasXptPositionDescriber.NameStrRecordDefaultPosition;
        }

        /// <summary>
        /// Throws the exception if the header does not satisfy the required header
        /// </summary>
        /// <param name="sasXptDocumentStream">Provided XPT document stream</param>
        private void ThrowIfInvalidHeader(string headerRecord)
        {
            SasXptInvalidHeaderRecordException.ThrowIfInvalidHeaderRecord(headerRecord, SasXptHeaderRecordDescriber.SasXptNameSrtHeader);
        }

        /// <summary>
        /// Reads next record from XPT document
        /// </summary>
        /// <param name="documentStream">The stream representing XPT document</param>
        /// <param name="bufferSize">The size of the record</param>
        /// <param name="offset">The required offset</param>
        /// <returns>Read array of bytes from the document</returns>
        private byte[] ReadNextXptRecord(Stream documentStream, int bufferSize, int offset = default)
        {
            var bufferToRead = new byte[bufferSize];
            documentStream.Read(bufferToRead, offset, bufferToRead.Length);
            return bufferToRead;
        }

        /// <summary>
        /// Provides the string from array of bytes
        /// </summary>
        /// <param name="bytes">The array of bytes will be converted to a string</param>
        /// <returns>Converted string</returns>
        private string GetStringFromParsedBytes(byte[] bytes)
        {
            return this.byteProcessor.ConvertBytesToString(bytes);
        }

        /// <summary>
        /// Gets number of XPT variables from XPT header
        /// </summary>
        /// <param name="sasXptNameStrHeader">The stream representing XPT document</param>
        /// <returns>Parsed count of XPT variables</returns>
        private int GetVariableNumbersFromHeader(string sasXptNameStrHeader)
        {
            var stringRepresentation = sasXptNameStrHeader
                .Substring(SasXptPositionDescriber.VariableOffsetPosition, SasXptElementLengthDescriber.VariableByteLength);

            return int.Parse(stringRepresentation);
        }
    }
}