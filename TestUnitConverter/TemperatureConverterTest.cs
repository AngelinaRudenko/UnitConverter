using NUnit.Framework;
using UnitConverter;

namespace TestUnitConverter
{
    public class TemperatureConverterTest
    {
        public Converter Converter;

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
        }

        [Test]
        public void CelsiusToFahrenheit_100CelsiusToFahrenheit_3p28()
        {
            var fromValue = 100;
            var fromUnitName = "Celsius";
            var toUnitName = "Fahrenheit";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("212 fahrenheit", result);
        }

        [Test]
        public void FahrenheitToCelsius_100FahrenheitToCelsius_3p28()
        {
            var fromValue = 100;
            var fromUnitName = "Fahrenheit";
            var toUnitName = "Celsius";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("37.78 celsius", result);
        }
    }
}
