using SasXptParser.Abstract;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace SasXptParser
{
    /// <summary>
    /// Provides methods for dealing bytes
    /// </summary>
    public sealed class SasXptByteProcessor : ISasXptByteProcessor
    {
        /// <summary>
        /// Holds a collection of convertors 
        /// </summary>
        private readonly ConcurrentDictionary<int, Func<byte[], int>> converters;

        /// <summary>
        /// Initializes the instance setting up the convertors 
        /// </summary>
        public SasXptByteProcessor()
        {
            this.converters = new ConcurrentDictionary<int, Func<byte[], int>>();
            this.converters.TryAdd(1, bytes => bytes.First());
            this.converters.TryAdd(2, bytes => BitConverter.ToInt16(bytes));
            this.converters.TryAdd(4, bytes => BitConverter.ToInt32(bytes));
        }

        /// <summary>
        /// Extracts a subset from provided array of bytes   
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <param name="start">Provided index for determining the start extracting position</param>
        /// <param name="count">Determines the count of extracted bytes</param>
        /// <returns>Extracted subset of bytes</returns>
        public byte[] GetSubsetFromByteArray(byte[] bytes, int start, int count)
        {
            try
            {
                byte[] buffer = new byte[count];

                if (count + start <= bytes.Length)
                    Buffer.BlockCopy(bytes, start, buffer, 0, count);

                return buffer;
            }
            catch (Exception)
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// Converts provided array of bytes to Int16 value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing Int16</returns>
        public short ConvertBytesToShort(byte[] bytes)
        {
            return bytes.Length == 1 ? bytes.First() : BitConverter.ToInt16(bytes);
        }

        /// <summary>
        /// Converts provided array of bytes to Int32 value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing Int32</returns>
        public int ConvertBytesToInt(byte[] bytes)
        {
            this.converters.TryGetValue(bytes.Length, out var converter);
            return converter != null ? converter(bytes) : default(int);
        }

        /// <summary>
        /// Converts provided array of bytes to String value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing String. If the bytes are empty, so empty string will be returned</returns>
        public string ConvertBytesToString(byte[] bytes)
        {
            var nullTerminator = "\0";

            return this.CheckIfEmptyBytes(bytes) ? string.Empty :
                Encoding.UTF8.GetString(bytes).Replace(nullTerminator, string.Empty).Trim();
        }

        /// <summary>
        /// Converts provided array of bytes to DateTime value
        /// </summary>
        /// <param name="bytes">Provided array of bytes</param>
        /// <returns>Converted value representing DateTime. If the bytes are empty, so current DateTime will be returned</returns>
        public DateTime ConvertBytesToDateTime(byte[] bytes)
        {
            var format = "ddMMMyy:HH:mm:ss";

            return this.CheckIfEmptyBytes(bytes) ? DateTime.Now :
                DateTime.ParseExact(this.ConvertBytesToString(bytes), format, CultureInfo.InvariantCulture);
        }

        // <summary>
        /// Checks if bytes are empty (0)
        /// </summary>
        /// <param name="byteArray">Provided array of bytes</param>
        /// <returns>True if bytes are empty, otherwise False</returns>
        public bool CheckIfEmptyBytes(byte[] byteArray)
        {
            return byteArray.All(current => current == 0);
        }

        /// <summary>
        /// Converts LittleEndian to the BigEndian
        /// </summary>
        /// <returns>Value converted into BigEndian</returns>
        public int ConvertToBigEndian(int littleEndian)
        {
            return IPAddress.HostToNetworkOrder(littleEndian);
        }

        /// <summary>
        /// Converts LittleEndian to the BigEndian
        /// </summary>
        /// <returns>Value converted into BigEndian</returns>
        public int ConvertToBigEndian(short littleEndian)
        {
            return IPAddress.HostToNetworkOrder(littleEndian);
        }
    }
}