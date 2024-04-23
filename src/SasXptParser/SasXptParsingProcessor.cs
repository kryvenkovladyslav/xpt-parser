using SasXptParser.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SasXptParser
{
    /// <summary>
    /// Provides methods for processing the XPT document
    /// </summary>
    public class SasXptParsingProcessor : ISasXptParsingProcessor
    {
        /// <summary>
        /// Holds a collection of parsers for parsing the XPT document
        /// </summary>
        protected IEnumerable<ISasXptParser<ISasXptElement>> Parsers { get; private init; }

        /// <summary>
        /// Initializes the instance using a collection of parsers 
        /// </summary>
        /// <param name="parsers">Provided collection of parsers</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException is thrown if parsers are not provided</exception>
        public SasXptParsingProcessor(IEnumerable<ISasXptParser<ISasXptElement>> parsers)
        {
            this.Parsers = parsers ?? throw new ArgumentNullException(nameof(parsers));
        }

        /// <summary>
        /// Parses the entire XPT document
        /// </summary>
        /// <param name="sasXptDocumentStream">The stream representing XPT document</param>
        /// <returns>Parsed XPT document</returns>
        public virtual  SasXptDocument ParseDocument(Stream sasXptDocumentStream)
        {
            var parsedDocument = new SasXptDocument();

            var properties = parsedDocument.GetType().GetProperties();

            foreach (var property in properties)
            {
                var requiredParser = this.Parsers.First(parser =>
                {
                    var parserType = parser.GetType();
                    var returnType = parserType.GetMethod(nameof(parser.ParseElement)).ReturnType;
                    return returnType == property.PropertyType;
                });

                property.SetValue(parsedDocument, requiredParser.ParseElement(sasXptDocumentStream));
            }

            return parsedDocument;
        }
    }
}