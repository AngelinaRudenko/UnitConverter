using NUnit.Framework;
using UnitConverter;

namespace TestUnitConverter
{
    public class MetricPrefixesTest
    {
        public Converter Converter;

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
        }

        [Test]
        public void KiloinchesToMeters_3KiloinchesToMeters_76p20()
        {
            var fromValue = 3;
            var fromUnitName = "KiLoinches";
            var toUnitName = "Meters";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("76.2 meters", result);
        }

        [Test]
        public void TerabyteToTerabit_1TerabyteToTerabit_8()
        {
            var fromValue = 1;
            var fromUnitName = "TERAbyte";
            var toUnitName = "TERAbit";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("8 terabits", result);
        }
    }
}
