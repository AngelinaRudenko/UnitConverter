using NUnit.Framework;
using UnitConverter;

namespace TestUnitConverter
{
    public class DataConverterTest
    {
        public Converter Converter;

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
        }

        [Test]
        public void BitsToBytes_100BitsToBytes_12p5()
        {
            var fromValue = 100;
            var fromUnitName = "Bits";
            var toUnitName = "Bytes";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("12.50 bytes", result);
        }

        [Test]
        public void BytesToBits_100BytesToBits_800()
        {
            var fromValue = 100;
            var fromUnitName = "Bytes";
            var toUnitName = "Bits";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("800.00 bits", result);
        }
    }
}
