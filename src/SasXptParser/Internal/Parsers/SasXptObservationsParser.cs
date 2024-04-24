using SasXptParser.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SasXptParser.Internal
{
    /// <summary>
    /// Provides methods for parsing XPT observation records into .NET objects
    /// </summary>
    internal sealed class SasXptObservationsParser : ISasXptObservationParser
    {
        /// <summary>
        /// Provides methods for dealing with array of bytes
        /// </summary>
        private readonly ISasXptByteProcessor byteProcessor;

        /// <summary>
        /// Initializes the instance using ISasXptByteProcessor 
        /// </summary>
        /// <param name="byteProcessor">The instance of ISasXptByteProcessor</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException is thrown if instance is not provided</exception>
        public SasXptObservationsParser(ISasXptByteProcessor byteProcessor)
        {
            this.byteProcessor = byteProcessor ?? throw new ArgumentNullException(nameof(byteProcessor));
        }

        /// <summary>
        /// Parses observations records of the XPT document into .NET objects
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <param name="variables">Parsed XPT variables</param>
        /// <returns>A collection of parsed observations from provided XPT document</returns>
        public IEnumerable<SasXptObservation> ParseObservations(Stream sasXptDocumentStream, IEnumerable<SasXptVariable> variables)
        {
            this.ReadNextXptRecord(sasXptDocumentStream, SasXptElementLengthDescriber.HeaderRecordByteLength);

            var length = this.GetObservationLength(variables);
            var streamLength = sasXptDocumentStream.Length - sasXptDocumentStream.Position;

            var observations = new List<SasXptObservation>();
            while (streamLength > length)
            {
                observations.Add(this.ReadObservationRecord(length, sasXptDocumentStream, variables));
                streamLength -= length;
            }

            return observations;
        }

        /// <summary>
        /// Provides the length of the observation records in XPT document
        /// </summary>
        /// <param name="variables">A collection of parsed XPT variables</param>
        /// <returns>Evaluated length of the XPT observation records</returns>
        private int GetObservationLength(IEnumerable<SasXptVariable> variables)
        {
            return variables.Select(variable => variable.Length).Sum();
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
        /// Reads next observation record of XPT document
        /// </summary>
        /// <param name="length">The length of the record will be read</param>
        /// <param name="stream">The stream representing XPT document</param>
        /// <param name="variables">The parsed XPT variable</param>
        /// <returns>Parsed observation record from XPT document</returns>
        private SasXptObservation ReadObservationRecord(int length, Stream stream, IEnumerable<SasXptVariable> variables)
        {
            var observation = new SasXptObservation();
            var buffer = this.ReadNextXptRecord(stream, length);

            foreach (var variable in variables)
            {
                var requiredSubset = this.byteProcessor.GetSubsetFromByteArray(buffer, variable.Position, variable.Length);
                var observationValue = this.ParseObservationValue(requiredSubset, variable.VariableType);

                if (!string.IsNullOrEmpty(observationValue))
                    observation.Rows.Add(new SasXptObservationRow(observationValue));
            }

            return observation;
        }

        /// <summary>
        /// Parses provided XPT observation value
        /// </summary>
        /// <param name="bytes">The array of bytes will be parsed</param>
        /// <param name="variableType">The type of the parsed XPT value</param>
        /// <returns>Parsed XPT observation value</returns>
        private string ParseObservationValue(byte[] bytes, SasXptVariableTypes variableType)
        {
            return variableType == SasXptVariableTypes.Character ? GetStringFromParsedBytes(bytes) : string.Empty;
        }
    }
}