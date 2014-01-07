using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type2Byte.BaseConverters
{
    public class B2T
    {
        public static bool IsLittleEndian { get; private set; }

        static B2T()
        {
            IsLittleEndian = DetermineIfLittleEndian();
        }

        public static T Get<T>(byte[] value, int startIndex = 0)
        {
            if (typeof(T) == typeof(bool)) return (T)(object)GetBool(value, startIndex);
            if (typeof(T) == typeof(byte)) return (T)(object)GetByte(value, startIndex);
            if (typeof(T) == typeof(sbyte)) return (T)(object)GetSByte(value, startIndex);
            if (typeof(T) == typeof(char)) return (T)(object)GetChar(value, startIndex);
            if (typeof(T) == typeof(float)) return (T)(object)GetFloat(value, startIndex);
            if (typeof(T) == typeof(double)) return (T)(object)GetDouble(value, startIndex);
            if (typeof(T) == typeof(int)) return (T)(object)GetInt(value, startIndex);
            if (typeof(T) == typeof(uint)) return (T)(object)GetUInt(value, startIndex);
            if (typeof(T) == typeof(long)) return (T)(object)GetLong(value, startIndex);
            if (typeof(T) == typeof(ulong)) return (T)(object)GetULong(value, startIndex);
            if (typeof(T) == typeof(short)) return (T)(object)GetShort(value, startIndex);
            if (typeof(T) == typeof(ushort)) return (T)(object)GetUShort(value, startIndex);
            if (typeof(T) == typeof(string)) return (T)(object)GetString(value, startIndex);
            throw new DataException("Provided type ({0}) cannot be deserialized from given value. You must provide a valuetype (except struct and enum) or a string");
        }

        //TODO: Need to handle endianness. All information is encoded in little-endian style
        #region private getters

        private static bool DetermineIfLittleEndian()
        {
            var test = T2B.ToBytes('a');
            var result = Convert.ToChar((test[0] | test[1] << 8));
            return (result == 'a');
        }

        private static bool GetBool(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(bool) + startIndex)) throw new DataException("Provided data does not appear to be of type bool");
            HandleEndianness(value);
            var boolArray = new bool[1];
            Buffer.BlockCopy(value, startIndex, boolArray, 0, sizeof(bool));
            return boolArray[0];
            //return (boolArray.First() != 0);
        }

        private static byte GetByte(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(byte) + startIndex)) throw new DataException("Provided data does not appear to be of type byte");
            HandleEndianness(value);
            var byteArray = new byte[1];
            Buffer.BlockCopy(value, startIndex, byteArray, 0, sizeof(byte));
            return byteArray[0];
        }

        private static sbyte GetSByte(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(sbyte) + startIndex)) throw new DataException("Provided data does not appear to be of type sbyte");
            HandleEndianness(value);
            var SByteArray = new sbyte[1];
            Buffer.BlockCopy(value, startIndex, SByteArray, 0, sizeof(sbyte));
            return SByteArray[0];
        }

        private static char GetChar(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(char) + startIndex)) throw new DataException("Provided data does not appear to be of type char");
            HandleEndianness(value);
            var charArray = new char[1];
            Buffer.BlockCopy(value, startIndex, charArray, 0, sizeof(char));
            return charArray[0];
        }

        private static float GetFloat(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(float) + startIndex)) throw new DataException("Provided data does not appear to be of type float");
            HandleEndianness(value);
            var floatArray = new float[1];
            Buffer.BlockCopy(value, startIndex, floatArray, 0, sizeof(float));
            return floatArray[0];
        }

        private static double GetDouble(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(double) + startIndex)) throw new DataException("Provided data does not appear to be of type double");
            HandleEndianness(value);
            var doubleArray = new double[1];
            Buffer.BlockCopy(value, startIndex, doubleArray, 0, sizeof(double));
            return doubleArray[0];
        }

        private static int GetInt(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(int) + startIndex)) throw new DataException("Provided data does not appear to be of type int");
            HandleEndianness(value);
            var intArray = new int[1];
            Buffer.BlockCopy(value, startIndex, intArray, 0, sizeof(int));
            return intArray[0];
        }

        private static uint GetUInt(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(uint) + startIndex)) throw new DataException("Provided data does not appear to be of type uint");
            HandleEndianness(value);
            var UIntArray = new uint[1];
            Buffer.BlockCopy(value, startIndex, UIntArray, 0, sizeof(uint));
            return UIntArray[0];
        }

        private static long GetLong(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(long) + startIndex)) throw new DataException("Provided data does not appear to be of type long");
            HandleEndianness(value);
            var LongArray = new long[1];
            Buffer.BlockCopy(value, startIndex, LongArray, 0, sizeof(long));
            return LongArray[0];
        }

        private static ulong GetULong(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(ulong) + startIndex)) throw new DataException("Provided data does not appear to be of type ulong");
            HandleEndianness(value);
            var ULongArray = new ulong[1];
            Buffer.BlockCopy(value, startIndex, ULongArray, 0, sizeof(ulong));
            return ULongArray[0];
        }

        private static short GetShort(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(short) + startIndex)) throw new DataException("Provided data does not appear to be of type short");
            HandleEndianness(value);
            var ShortArray = new short[1];
            Buffer.BlockCopy(value, startIndex, ShortArray, 0, sizeof(short));
            return ShortArray[0];
        }

        private static ushort GetUShort(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != (sizeof(ushort) + startIndex)) throw new DataException("Provided data does not appear to be of type ushort");
            HandleEndianness(value);
            var UShortArray = new ushort[1];
            Buffer.BlockCopy(value, startIndex, UShortArray, 0, sizeof(ushort));
            return UShortArray[0];
        }

        //TODO: Need to handle string offset
        private static string GetString(byte[] value, int startIndex)
        {
            var sb = new StringBuilder();
            HandleEndianness(value);
            foreach (var @char in value)
            {
                sb.Append(@char);
            }
            return sb.ToString();
        }

        private static void HandleEndianness(byte[] byteArray)
        {
            if (!IsLittleEndian) Array.Reverse(byteArray);
        }
        #endregion
    }
}
