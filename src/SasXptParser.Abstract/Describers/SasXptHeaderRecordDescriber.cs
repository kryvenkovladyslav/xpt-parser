namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides string representation of XPT headers
    /// </summary>
    public static class SasXptHeaderRecordDescriber
    {
        /// <summary>
        /// Provides XPT Library Header string representation 
        /// </summary>
        public static string SasXptLibraryHeader { get; } = "HEADER RECORD*******LIBRARY HEADER RECORD!!!!!!!000000000000000000000000000000";

        /// <summary>
        /// Provides XPT Member Descriptor Header string representation 
        /// </summary>
        public static string SasXptMemberDescriptor { get; } = "HEADER RECORD*******MEMBER  HEADER RECORD!!!!!!!000000000000000001600000000140";

        /// <summary>
        /// Provides XPT Variable Header string representation 
        /// </summary>
        public static string SasXptNameSrtHeader { get; } = "HEADER RECORD*******NAMESTR HEADER RECORD!!!!!!!000000000700000000000000000000";

        /// <summary>
        /// Provides XPT Observation Header string representation 
        /// </summary>
        public static string SasXptObsHeader { get; } = "HEADER RECORD*******OBS     HEADER RECORD!!!!!!!000000000000000000000000000000";
    }
}