using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type2Byte.BaseConverters
{
    public class T2B
    {
        public static byte[] ToBytes(bool value)
        {
            return new[] { (value) ? (byte)1 : (byte)0 };
        }

        public static byte[] ToBytes(sbyte value)
        {
            return new[] { (byte)value };
        }

        public static byte[] ToBytes(byte value)
        {
            return new[] { value };
        }

        public static byte[] ToBytes(char value)
        {
            var bytes = new byte[sizeof(char)];
            for (var i = sizeof(char) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }

            return bytes;
        }

        public static byte[] ToBytes(float value)
        {
            var floatArray = new[] { value };
            var byteArray = new byte[sizeof(float)];
            Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteArray.Length);

            return byteArray;
        }

        public static byte[] ToBytes(double value)
        {
            var doubleArray = new[] { value };
            var byteArray = new byte[sizeof(double)];
            Buffer.BlockCopy(doubleArray, 0, byteArray, 0, byteArray.Length);

            return byteArray;
        }

        public static byte[] ToBytes(short value)
        {
            var bytes = new byte[sizeof(short)];
            for (var i = sizeof(short) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }

            return bytes;
        }

        public static byte[] ToBytes(ushort value)
        {
            var bytes = new byte[sizeof(ushort)];
            for (var i = sizeof(ushort) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }

            return bytes;
        }

        public static byte[] ToBytes(int value)
        {
            var bytes = new byte[sizeof(int)];
            for (var i = sizeof(int) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }

            return bytes;
        }

        public static byte[] ToBytes(uint value)
        {
            var bytes = new byte[sizeof(uint)];
            for (var i = sizeof(uint) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }

            return bytes;
        }

        public static byte[] ToBytes(long value)
        {
            var bytes = new byte[sizeof(long)];
            for (var i = sizeof(long) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }

            return bytes;
        }

        public static byte[] ToBytes(ulong value)
        {
            var bytes = new byte[sizeof(ulong)];
            for (var i = sizeof(ulong) - 1; i >= 0; i--)
            {
                bytes[Math.Abs((~i) + 1)] = (byte)(value >> 8 * i);
            }
            return bytes;
        }
    }
}
