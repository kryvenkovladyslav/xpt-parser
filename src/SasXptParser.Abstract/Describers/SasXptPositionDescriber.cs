namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides default starting position of XPT headers
    /// </summary>
    public static class SasXptPositionDescriber
    {
        /// <summary>
        /// Provider the length for XPT variable offset
        /// </summary>
        public static byte VariableOffsetPosition { get; } = 54;

        /// <summary>
        /// Provider the starting position for XPT Library Header Record
        /// </summary>
        public static int LibraryHeaderRecordDefaultPosition { get; } = 0;

        /// <summary>
        /// Provider the starting position for XPT Member Descriptor Header Record
        /// </summary>
        public static int MemberDescriptorRecordDefaultPosition { get; } = 240;

        /// <summary>
        /// Provider the starting position for XPT Name Str Header Record
        /// </summary>
        public static int NameStrRecordDefaultPosition { get; } = 560;
    }
}