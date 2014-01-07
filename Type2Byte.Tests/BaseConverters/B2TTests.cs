using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type2Byte.BaseConverters;

namespace Type2Byte.Tests.BaseConverters
{
    //TODO: Need to not use T2B to provide expected arrays. Need to manually compute arrays and plug them in
    [TestFixture]
    class B2TTests
    {
        [Test]
        public void GetT_ThrowsDataException_WhenInvlaidTypeIsGiven()
        {
            Assert.Throws<DataException>(() =>
            {
                var thing = B2T.Get<Action>(new byte[1]);
            });
        }

        #region GetBool tests
        [Test]
        public void GetBool_ReturnsCorrectBool_WhenStartIndexIsZero()
        {
            const bool expectedBool = false;

            var actualBool = B2T.Get<bool>(T2B.ToBytes(expectedBool));

            Assert.AreEqual(expectedBool, actualBool);
        }

        [Test]
        public void GetBool_ReturnsCorrectBool_WhenStartIndexIsNotZero()
        {
            const bool expectedBool = true;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedBool));
            var actualBool = B2T.Get<bool>(bytes, offset);

            Assert.AreEqual(expectedBool, actualBool);
        }

        [Test]
        public void GetBool_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<bool>(null);
            });
        }

        [Test]
        public void GetBool_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(false));

            Assert.Throws<DataException>(() =>
            {
                var actualBool = B2T.Get<bool>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetByte tests
        [Test]
        public void GetByte_ReturnsCorrectByte_WhenStartIndexIsZero()
        {
            const byte expectedByte = 0x7e;

            var actualByte = B2T.Get<byte>(T2B.ToBytes(expectedByte));

            Assert.AreEqual(expectedByte, actualByte);
        }

        [Test]
        public void GetByte_ReturnsCorrectByte_WhenStartIndexIsNotZero()
        {
            const byte expectedByte = 0x6f;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedByte));
            var actualByte = B2T.Get<byte>(bytes, offset);

            Assert.AreEqual(expectedByte, actualByte);
        }

        [Test]
        public void GetByte_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<byte>(null);
            });
        }

        [Test]
        public void GetByte_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(0xff));

            Assert.Throws<DataException>(() =>
            {
                var actualByte = B2T.Get<byte>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetSByte tests
        [Test]
        public void GetSByte_ReturnsCorrectSByte_WhenStartIndexIsZero()
        {
            const sbyte expectedSByte = -0x45;

            var actualSByte = B2T.Get<sbyte>(T2B.ToBytes(expectedSByte));

            Assert.AreEqual(expectedSByte, actualSByte);
        }

        [Test]
        public void GetSByte_ReturnsCorrectSByte_WhenStartIndexIsNotZero()
        {
            const sbyte expectedSByte = -0x68;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedSByte));
            var actualSByte = B2T.Get<sbyte>(bytes, offset);

            Assert.AreEqual(expectedSByte, actualSByte);
        }

        [Test]
        public void GetDByte_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<sbyte>(null);
            });
        }

        [Test]
        public void GetSByte_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(-0x22));

            Assert.Throws<DataException>(() =>
            {
                var actualByte = B2T.Get<sbyte>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetChar tests
        [Test]
        public void GetChar_ReturnsCorrectChar_WhenStartIndexIsZero()
        {
            const char expectedChar = 'a';

            var actualChar = B2T.Get<char>(T2B.ToBytes(expectedChar));

            Assert.AreEqual(expectedChar, actualChar);
        }

        [Test]
        public void GetChar_ReturnsCorrectChar_WhenStartIndexIsNotZero()
        {
            const char expectedChar = 'b';
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedChar));
            var actualChar = B2T.Get<char>(bytes, offset);

            Assert.AreEqual(expectedChar, actualChar);
        }

        [Test]
        public void GetChar_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<char>(null);
            });
        }

        [Test]
        public void GetChar_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes('b'));

            Assert.Throws<DataException>(() =>
            {
                var actualChar = B2T.Get<char>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetFloat tests
        [Test]
        public void GetFloat_ReturnsCorrectFloat_WhenPowerIsHigh()
        {
            const float expectedFloat = (float)4e-32;
            const float epsilon = (float)1e-36;

            var actualFloat = B2T.Get<float>(T2B.ToBytes(expectedFloat));

            Assert.LessOrEqual(expectedFloat - actualFloat, epsilon);
        }

        [Test]
        public void GetFloat_ReturnsCorrectFloat_WhenPowerIsLow()
        {
            const float expectedFloat = (float)4e4;
            const float epsilon = 1.0F;

            var actualFloat = B2T.Get<float>(T2B.ToBytes(expectedFloat));

            Assert.LessOrEqual(expectedFloat - actualFloat, epsilon);
        }

        [Test]
        public void GetFloat_ReturnsCorrectFloat_WhenStartIndexIsZero()
        {
            const float expectedFloat = 1.0F;

            var actualChar = B2T.Get<float>(T2B.ToBytes(expectedFloat));

            Assert.AreEqual(expectedFloat, actualChar);
        }

        [Test]
        public void GetFloat_ReturnsCorrectFloat_WhenStartIndexIsNotZero()
        {
            const float expectedFloat = 1.0F;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedFloat));
            var actualFloat = B2T.Get<float>(bytes, offset);

            Assert.AreEqual(expectedFloat, actualFloat);
        }

        [Test]
        public void GetFloat_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<float>(null);
            });
        }

        [Test]
        public void GetFloat_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(2.5F));

            Assert.Throws<DataException>(() =>
            {
                var actualFloat = B2T.Get<float>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetDouble tests
        [Test]
        public void GetDouble_ReturnsCorrectDouble_WhenPowerIsHigh()
        {
            const double expectedDouble = 4e64;
            const double epsilon = 1e-36;

            var actualDouble = B2T.Get<double>(T2B.ToBytes(expectedDouble));

            Assert.LessOrEqual(expectedDouble - actualDouble, epsilon);
        }

        [Test]
        public void GetDouble_ReturnsCorrectDouble_WhenPowerIsLow()
        {
            const double expectedDouble = 4e-2;
            const double epsilon = 1e-6;

            var actualDouble = B2T.Get<double>(T2B.ToBytes(expectedDouble));

            Assert.LessOrEqual(expectedDouble - actualDouble, epsilon);
        }

        [Test]
        public void GetDouble_ReturnsCorrectDouble_WhenStartIndexIsZero()
        {
            const double expectedDouble = 4.0;

            var actualDouble = B2T.Get<double>(T2B.ToBytes(expectedDouble));

            Assert.AreEqual(expectedDouble, actualDouble);
        }

        [Test]
        public void GetDouble_ReturnsCorrectDouble_WhenStartIndexIsNotZero()
        {
            const double expectedDouble = 3.6;
            const int offset = 3;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedDouble));
            var actualDouble = B2T.Get<double>(bytes, offset);

            Assert.AreEqual(expectedDouble, actualDouble);
        }

        [Test]
        public void GetDouble_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<double>(null);
            });
        }

        [Test]
        public void GetDouble_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 5;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(2.3));

            Assert.Throws<DataException>(() =>
            {
                var actualDouble = B2T.Get<double>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetInt tests
        [Test]
        public void GetInt_ReturnsCorrectInt_WhenStartIndexIsZero()
        {
            const int expectedInt = 325;

            var actualInt = B2T.Get<int>(T2B.ToBytes(expectedInt));

            Assert.AreEqual(expectedInt, actualInt);
        }

        [Test]
        public void GetInt_ReturnsCorrectInt_WhenStartIndexIsNotZero()
        {
            const int expectedInt = 985;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedInt));
            var actualInt = B2T.Get<int>(bytes, offset);

            Assert.AreEqual(expectedInt, actualInt);
        }

        [Test]
        public void GetInt_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<int>(null);
            });
        }

        [Test]
        public void GetInt_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(965));

            Assert.Throws<DataException>(() =>
            {
                var actualInt = B2T.Get<int>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetUInt tests
        public void GetUInt_ReturnsCorrectUInt_WhenStartIndexIsZero()
        {
            const uint expectedUInt = 435234;

            var actualUInt = B2T.Get<uint>(T2B.ToBytes(expectedUInt));

            Assert.AreEqual(expectedUInt, actualUInt);
        }

        [Test]
        public void GetUInt_ReturnsCorrectUInt_WhenStartIndexIsNotZero()
        {
            const uint expectedUInt = 943052234;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedUInt));
            var actualUInt = B2T.Get<uint>(bytes, offset);

            Assert.AreEqual(expectedUInt, actualUInt);
        }

        [Test]
        public void GetUInt_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<uint>(null);
            });
        }

        [Test]
        public void GetUInt_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes((uint)9653453));

            Assert.Throws<DataException>(() =>
            {
                var actualUint = B2T.Get<uint>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetLong tests
        public void GetLong_ReturnsCorrectLong_WhenStartIndexIsZero()
        {
            const long expectedLong = 4352346566;

            var actualLong = B2T.Get<long>(T2B.ToBytes(expectedLong));

            Assert.AreEqual(expectedLong, actualLong);
        }

        [Test]
        public void GetLong_ReturnsCorrectLong_WhenStartIndexIsNotZero()
        {
            const long expectedLong = 943052234;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedLong));
            var actualLong = B2T.Get<long>(bytes, offset);

            Assert.AreEqual(expectedLong, actualLong);
        }

        [Test]
        public void GetLong_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<long>(null);
            });
        }

        [Test]
        public void GetLong_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(96534534566));

            Assert.Throws<DataException>(() =>
            {
                var actualLong = B2T.Get<long>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetULong tests
        public void GetULong_ReturnsCorrectULong_WhenStartIndexIsZero()
        {
            const ulong expectedULong = 4352346566;

            var actualULong = B2T.Get<ulong>(T2B.ToBytes(expectedULong));

            Assert.AreEqual(expectedULong, actualULong);
        }

        [Test]
        public void GetULong_ReturnsCorrectULong_WhenStartIndexIsNotZero()
        {
            const ulong expectedULong = 943052234;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedULong));
            var actualULong = B2T.Get<ulong>(bytes, offset);

            Assert.AreEqual(expectedULong, actualULong);
        }

        [Test]
        public void GetULong_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<ulong>(null);
            });
        }

        [Test]
        public void GetULong_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes((ulong)96534534566));

            Assert.Throws<DataException>(() =>
            {
                var actuaUlLong = B2T.Get<ulong>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetShort tests
        public void GetShort_ReturnsCorrectShort_WhenStartIndexIsZero()
        {
            const short expectedShort = 5647;

            var actualShort = B2T.Get<short>(T2B.ToBytes(expectedShort));

            Assert.AreEqual(expectedShort, actualShort);
        }

        [Test]
        public void GetShort_ReturnsCorrectShort_WhenStartIndexIsNotZero()
        {
            const short expectedShort = 3245;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedShort));
            var actualShort = B2T.Get<short>(bytes, offset);

            Assert.AreEqual(expectedShort, actualShort);
        }

        [Test]
        public void GetShort_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<short>(null);
            });
        }

        [Test]
        public void GetShort_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes((short)6585));

            Assert.Throws<DataException>(() =>
            {
                var actualShort = B2T.Get<short>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetUShort tests
        public void GetUShort_ReturnsCorrectUShort_WhenStartIndexIsZero()
        {
            const ushort expectedUShort = 5647;

            var actualUShort = B2T.Get<ushort>(T2B.ToBytes(expectedUShort));

            Assert.AreEqual(expectedUShort, actualUShort);
        }

        [Test]
        public void GetUShort_ReturnsCorrectUShort_WhenStartIndexIsNotZero()
        {
            const ushort expectedUShort = 3245;
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(expectedUShort));
            var actualUShort = B2T.Get<ushort>(bytes, offset);

            Assert.AreEqual(expectedUShort, actualUShort);
        }

        [Test]
        public void GetUShort_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<ushort>(null);
            });
        }

        [Test]
        public void GetUShort_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes((ushort)6754));

            Assert.Throws<DataException>(() =>
            {
                var actualUShort = B2T.Get<ushort>(bytes, offset - 1);
            });
        }
        #endregion

        #region GetString tests
        [Test]
        public void GetString_ReturnsCorrectString_WhenStartIndexIsZero()
        {
            const string expectedString = "awesomesauce";

            var actualString = B2T.Get<string>(T2B.ToBytes(expectedString));

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void GetString_ReturnsCorrectString_WhenStartIndexIsNotZero()
        {
            const string expectedString = "captain-wootpants";
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset * 2, T2B.ToBytes(expectedString));
            var actualString = B2T.Get<string>(bytes, offset);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void GetString_ThrowsArgumentNullException_WhenNullIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                B2T.Get<string>(null);
            });
        }

        [Test]
        public void GetString_ThrowsDataException_WhenInvalidStartIndexIsProvided()
        {
            const int offset = 2;

            var bytes = CreateByteListWithPrepend(offset, T2B.ToBytes(""));

            Assert.Throws<DataException>(() =>
            {
                var actualString = B2T.Get<string>(bytes, offset);
            });
        }
        #endregion

        #region Private helpers
        private byte[] CreateByteListWithPrepend(int prependAmount, byte[] data)
        {
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < prependAmount; i++)
                byteList.Add(default(byte));
            byteList.AddRange(data);

            return byteList.ToArray();
        }

        private byte[] CreateByteListWithPrependFromString(int prependAmount, string data)
        {
            byte[] converted = T2B.ToBytes(data);
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < prependAmount; i++)
            {
                byteList.Add(default(byte));
            }     
            byteList.AddRange(converted);

            return byteList.ToArray();
        }


        #endregion
    }
}
