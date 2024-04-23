using System;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Represents the exception thrown if the record header is invalid
    /// </summary>
    [Serializable]
    public class SasXptInvalidHeaderRecordException : Exception
    {
        /// <summary>
        /// Default constructor for creating an instance 
        /// </summary>
        public SasXptInvalidHeaderRecordException() : this(ExceptionMessages.SasXptInvalidHeaderRecordExceptionMessage) { }

        /// <summary>
        /// Constructor with provided custom exception message
        /// </summary>
        /// <param name="message">Provided exception message</param>
        public SasXptInvalidHeaderRecordException(string message) : base(message ?? ExceptionMessages.SasXptInvalidHeaderRecordExceptionMessage) { }

        /// <summary>
        /// Raises the exception is header is invalid
        /// </summary>
        /// <param name="headerRecord">Provided XPT header record</param>
        public static void ThrowIfInvalidHeaderRecord(string headerRecord, string requiredHeaderRecord)
        {
            if (headerRecord == null || !headerRecord.StartsWith(requiredHeaderRecord))
                throw new SasXptInvalidHeaderRecordException($"The Header Record Should be {requiredHeaderRecord}, but {headerRecord} was provided");
        }
    }
}