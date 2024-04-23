using SasXptParser.Abstract;
using System;
using System.IO;

namespace SasXptParser
{
    /// <summary>
    /// Provides methods for parsing data records of the XPT documents into .NET objects
    /// </summary>
    public class SasXptDataRecordParser : ISasXptParser<SasXptDataRecord>
    {
        /// <summary>
        /// Provides parsing of XPT variables into .NET objects
        /// </summary>
        protected ISasXptVariableParser VariableParser { get; private init; }

        /// <summary>
        /// Provides parsing of XPT observations into .NET objects
        /// </summary>
        protected ISasXptObservationParser ObservationParser { get; private init; }

        /// <summary>
        /// Initializes the instances using ISasXptVariablesParser and ISasXptObservationParser instances
        /// </summary>
        /// <exception cref="ArgumentNullException">The ArgumentNullException is thrown if the instances are not provided</exception>
        public SasXptDataRecordParser(ISasXptVariableParser variablesParser, ISasXptObservationParser observationParser) 
        {
            this.VariableParser = variablesParser ?? throw new ArgumentNullException(nameof(variablesParser));
            this.ObservationParser = observationParser ?? throw new ArgumentNullException(nameof(observationParser));
        }

        /// <summary>
        /// Parses the specified XPT element into .NET object
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <returns>Parse XPT element against the parser</returns>
        public virtual SasXptDataRecord ParseElement(Stream sasXptDocumentStream)
        {
            ArgumentNullException.ThrowIfNull(nameof(sasXptDocumentStream));

            var parsedVariables = this.VariableParser.ParseVariables(sasXptDocumentStream);

            var delta = sasXptDocumentStream.Position % SasXptElementLengthDescriber.HeaderRecordByteLength;
            sasXptDocumentStream.Position = delta == 0 ? sasXptDocumentStream.Position :
                sasXptDocumentStream.Position + (SasXptElementLengthDescriber.HeaderRecordByteLength - delta);

            var parsedObservation = this.ObservationParser.ParseObservations(sasXptDocumentStream, parsedVariables);

            return new SasXptDataRecord
            {
                Variables = parsedVariables,
                Observations = parsedObservation
            };
        }
    }
}