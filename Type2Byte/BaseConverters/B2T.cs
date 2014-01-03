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

        public static T Get<T>(byte[] value)
        {
            if (typeof(T) == typeof(bool)) return (T)(object)GetBool(value);
            if (typeof(T) == typeof(byte)) return (T)(object)GetByte(value);
            if (typeof(T) == typeof(sbyte)) return (T)(object)GetSByte(value);
            if (typeof(T) == typeof(char)) return (T)(object)GetChar(value);
            if (typeof(T) == typeof(float)) return (T)(object)GetFloat(value);
            if (typeof(T) == typeof(double)) return (T)(object)GetDouble(value);
            if (typeof(T) == typeof(int)) return (T)(object)GetInt(value);
            if (typeof(T) == typeof(uint)) return (T)(object)GetUInt(value);
            if (typeof(T) == typeof(long)) return (T)(object)GetLong(value);
            if (typeof(T) == typeof(ulong)) return (T)(object)GetULong(value);
            if (typeof(T) == typeof(short)) return (T)(object)GetShort(value);
            if (typeof(T) == typeof(ushort)) return (T)(object)GetUShort(value);
            if (typeof(T) == typeof(string)) return (T)(object)GetString(value);
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

        private static bool GetBool(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(bool)) throw new DataException("Provided data does not appear to be of type bool");
            HandleEndianness(value);
            return (value.First() != 0);
        }

        private static byte GetByte(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(byte)) throw new DataException("Provided data does not appear to be of type byte");
            HandleEndianness(value);
            return value.First();
        }

        private static sbyte GetSByte(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(sbyte)) throw new DataException("Provided data does not appear to be of type sbyte");
            HandleEndianness(value);
            return (sbyte)value.First();
        }

        private static char GetChar(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(char)) throw new DataException("Provided data does not appear to be of type char");
            HandleEndianness(value);
            return Convert.ToChar((value[0] | value[1] << 8));
        }

        private static float GetFloat(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(float)) throw new DataException("Provided data does not appear to be of type float");
            HandleEndianness(value);
            var floatArray = new float[1];
            Buffer.BlockCopy(value, startIndex, floatArray, 0, value.Length - startIndex);
            return floatArray[0];
        }

        private static double GetDouble(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(double)) throw new DataException("Provided data does not appear to be of type double");
            HandleEndianness(value);
            var doubleArray = new double[1];
            Buffer.BlockCopy(value, startIndex, doubleArray, 0, value.Length - startIndex);
            return doubleArray[0];
        }

        private static int GetInt(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(int)) throw new DataException("Provided data does not appear to be of type int");
            HandleEndianness(value);
            return (value[0] << 0) | (value[1] << 8) | (value[2] << 16) | (value[3] << 24);
        }

        private static uint GetUInt(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(uint)) throw new DataException("Provided data does not appear to be of type uint");
            HandleEndianness(value);
            return Convert.ToUInt32((value[0] << 0) | (value[1] << 8) | (value[2] << 16) | (value[3] << 24));
        }

        private static long GetLong(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(long)) throw new DataException("Provided data does not appear to be of type long");
            HandleEndianness(value);
            return Convert.ToInt64((value[0] << 0) | (value[1] << 8) | (value[2] << 16) | (value[3] << 24 | value[4] << 32) | (value[5] << 40) | (value[6] << 48) | (value[7] << 56));
        }

        private static ulong GetULong(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(ulong)) throw new DataException("Provided data does not appear to be of type ulong");
            HandleEndianness(value);
            return Convert.ToUInt64((value[0] << 0) | (value[1] << 8) | (value[2] << 16) | (value[3] << 24 | value[4] << 32) | (value[5] << 40) | (value[6] << 48) | (value[7] << 56));
        }

        private static short GetShort(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(ulong)) throw new DataException("Provided data does not appear to be of type ulong");
            HandleEndianness(value);
            return Convert.ToInt16((value[0] << 0) | (value[1] << 8));
        }

        private static ushort GetUShort(byte[] value, int startIndex = 0)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length != sizeof(ulong)) throw new DataException("Provided data does not appear to be of type ulong");
            HandleEndianness(value);
            return Convert.ToUInt16((value[0] << 0) | (value[1] << 8));
        }

        private static string GetString(byte[] value, int startIndex = 0)
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
