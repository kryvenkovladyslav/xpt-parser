namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides default lengths of XPT elements
    /// </summary>
    public static class SasXptElementLengthDescriber
    {
        /// <summary>
        /// Provider the length for XPT Header Record
        /// </summary>
        public static byte HeaderRecordByteLength { get; } = 80;

        /// <summary>
        /// Provider the length for XPT Observation Record
        /// </summary>
        public static byte ObservationRecordByteLength { get; } = 140;

        /// <summary>
        /// Provider the length for XPT variable
        /// </summary>
        public static byte VariableByteLength { get; } = 4;
    }
}