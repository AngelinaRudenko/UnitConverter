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
            Assert.AreEqual("76.20 meters", result);
        }

        [Test]
        public void TerabyteToTerabit_1TerabyteToTerabit_8()
        {
            var fromValue = 1;
            var fromUnitName = "TERAbyte";
            var toUnitName = "TERAbit";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("8.00 terabits", result);
        }

        [Test]
        public void MetersToKilometers_1500MetersToKilometers__1p5()
        {
            var fromValue = 1500;
            var fromUnitName = "Meters";
            var toUnitName = "Kilometers";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("1.50 kilometers", result);
        }

        [Test]
        public void KilometersToMeters_1p5KilometersToMeters__15000()
        {
            var fromValue = 15;
            var fromUnitName = "KILOMeters";
            var toUnitName = "meters";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("15000.00 meters", result);
        }
    }
}
