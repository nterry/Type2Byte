using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type2Byte.BaseConverters;

namespace Type2Byte.Tests.BaseConverters
{
    //TODO: Need to separate these tests to each individual type
    [TestFixture]
    public class BitConvertTests
    {
        [Test]
        public void ToBytes_ReturnsAppropriatelyBitConvertedValue()
        {
            var expectedSByte = new byte[] { 165 };
            var expectedByte = new byte[] { 45 };
            var expectedChar = new byte[] { 99, 0 };
            var expectedBool = new byte[] { 1 };
            var expectedInt = new byte[] { 89, 34, 255, 255 };
            var expectedUInt = new byte[] { 78, 97, 188, 0 };
            var expectedShort = new byte[] { 184, 17 };
            var expectedUShort = new byte[] { 145, 30 };
            var expectedLong = new byte[] { 184, 53, 185, 194, 219, 6, 0, 0 };
            var expectedULong = new byte[] { 15, 246, 250, 107, 91, 163, 32, 109 };
            var expectedFloat = new byte[] { 0, 64, 58, 71 };
            var expectedDouble = new byte[] { 103, 3, 166, 185, 64, 31, 18, 60 };

            var actualSByte = T2B.ToBytes((sbyte)-91);
            var actualByte = T2B.ToBytes((byte)45);
            var actualChar = T2B.ToBytes('c');
            var actualBool = T2B.ToBytes(true);
            var actualInt = T2B.ToBytes(-56743);
            var actualUInt = T2B.ToBytes((uint)12345678);
            var actualShort = T2B.ToBytes((short)4536);
            var actualUShort = T2B.ToBytes((ushort)7825);
            var actualLong = T2B.ToBytes(7540934522296);
            var actualULong = T2B.ToBytes((ulong)7863464562437846543);
            var actualFloat = T2B.ToBytes((float)4.768e4);
            var actualDouble = T2B.ToBytes(2456e-22);

            Assert.AreEqual(expectedSByte, actualSByte);
            Assert.AreEqual(expectedByte, actualByte);
            Assert.AreEqual(expectedChar, actualChar);
            Assert.AreEqual(expectedBool, actualBool);
            Assert.AreEqual(expectedInt, actualInt);
            Assert.AreEqual(expectedUInt, actualUInt);
            Assert.AreEqual(expectedShort, actualShort);
            Assert.AreEqual(expectedUShort, actualUShort);
            Assert.AreEqual(expectedLong, actualLong);
            Assert.AreEqual(expectedULong, actualULong);
            Assert.AreEqual(expectedFloat, actualFloat);
            Assert.AreEqual(expectedDouble, actualDouble);
        }
    }
}
