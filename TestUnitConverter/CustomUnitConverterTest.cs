using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitConverter;
using UnitConverter.Contracts;
using UnitConverter.Converters.Enum;

namespace TestUnitConverter
{
    public class CustomUnitConverterTest
    {
        public Converter Converter;

        public class MileConverter : ISpecificUnitConverter
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

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
            Converter.AddCustomConverter(ConverterCategory.Length, new []{ "Miles" }, new MileConverter());
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
