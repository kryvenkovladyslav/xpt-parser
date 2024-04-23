using System;

namespace SasXptParser.Abstract
{
    /// <summary>
    /// Provides methods for dealing bytes
    /// </summary>
    public interface ISasXptByteProcessor
    {
        /// <summary>
        /// Extracts a subset from provided array of bytes   
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <param name="start">Provided index for determining the start extracting position</param>
        /// <param name="count">Determines the count of extracted bytes</param>
        /// <returns>Extracted subset of bytes</returns>
        public byte[] GetSubsetFromByteArray(byte[] bytes, int start, int count);

        /// <summary>
        /// Converts provided array of bytes to Int16 value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing Int16</returns>
        public short ConvertBytesToShort(byte[] bytes);

        /// <summary>
        /// Converts provided array of bytes to Int32 value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing Int32</returns>
        public int ConvertBytesToInt(byte[] bytes);

        /// <summary>
        /// Converts provided array of bytes to String value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing String. If the bytes are empty, so empty string will be returned</returns>
        public string ConvertBytesToString(byte[] bytes);

        /// <summary>
        /// Converts provided array of bytes to DateTime value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing DateTime. If the bytes are empty, so current DateTime will be returned</returns>
        public DateTime ConvertBytesToDateTime(byte[] bytes);

        /// <summary>
        /// Checks if bytes are empty (0)
        /// </summary>
        /// <param name="byteArray">Provided array of bytes</param>
        /// <returns>True if bytes are empty, otherwise False</returns>
        public bool CheckIfEmptyBytes(byte[] byteArray);

        /// <summary>
        /// Converts LittleEndian to the BigEndian
        /// </summary>
        /// <returns>Value converted into BigEndian</returns>
        public int ConvertToBigEndian(int littleEndian);

        /// <summary>
        /// Converts LittleEndian to the BigEndian
        /// </summary>
        /// <returns>Value converted into BigEndian</returns>
        public int ConvertToBigEndian(short littleEndian);
    }
}