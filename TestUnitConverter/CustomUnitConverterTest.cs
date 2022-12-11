using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitConverter;
using UnitConverter.Converters.Base.Contracts;

namespace TestUnitConverter
{
    public class CustomUnitConverterTest
    {
        public Converter Converter;

        #region Specific Converter

        private class MileConverter : ISpecificUnitConverter
        {
            public string GetPluralNameForOutput => "miles";

            public double ToBase(double value)
            {
                return value * 1609.344;
            }

            public double FromBase(double value)
            {
                return value * 0.000621371192;
            }
        }

        #endregion

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
            Converter.AddCustomConverter("Length", new []{ "Miles" }, new MileConverter());
        }

        [Test]
        public void MetersToMiles_10000MetersToMiles_6p21()
        {
            var fromValue = 10000;
            var fromUnitName = "Meters";
            var toUnitName = "Miles";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("6.21 miles", result);
        }

        [Test]
        public void MilesToMeters_3MilesToMeters_4828p03()
        {
            var fromValue = 3;
            var fromUnitName = "Miles";
            var toUnitName = "Meters";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("4828.03 meters", result);
        }
    }
}
