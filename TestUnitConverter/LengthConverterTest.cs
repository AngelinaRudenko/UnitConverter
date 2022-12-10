using NUnit.Framework;
using UnitConverter;

namespace TestUnitConverter
{
    public class LengthConverterTest
    {
        public Converter Converter;

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
        }

        [Test]
        public void MetersToFeet_1MeterToFeet_3p28()
        {
            var fromValue = 1;
            var fromUnitName = "Meter";
            var toUnitName = "Feet";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("3.28 feet", result);
        }

        [Test]
        public void FeetToMeters_100FeetToMeters_30p48()
        {
            var fromValue = 100;
            var fromUnitName = "Feet";
            var toUnitName = "Meter";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("30.48 meters", result);
        }

        [Test]
        public void MetersToInches_100MetersToInches_30p48()
        {
            var fromValue = 100;
            var fromUnitName = "Meters";
            var toUnitName = "Inches";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("3937.01 inches", result);
        }

        [Test]
        public void InchesToMeters_100InchesToMeters_30p48()
        {
            var fromValue = 100;
            var fromUnitName = "Inches";
            var toUnitName = "Meters";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("2.54 meters", result);
        }
    }
}
