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
