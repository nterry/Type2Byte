using NUnit.Framework;
using System;
using System.Collections.Generic;
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
    }
}
