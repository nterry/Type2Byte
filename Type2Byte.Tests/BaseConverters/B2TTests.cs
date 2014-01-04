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
                var actualChar = B2T.Get<float>(bytes, offset - 1);
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

        #region Private helpers
        private byte[] CreateByteListWithPrepend(int prependAmount, byte[] data)
        {
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < prependAmount; i++)
                byteList.Add(default(byte));
            byteList.AddRange(data);

            return byteList.ToArray();
        }


        #endregion
    }
}
