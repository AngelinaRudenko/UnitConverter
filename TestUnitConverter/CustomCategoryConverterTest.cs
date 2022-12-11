using System.Collections.Generic;
using NUnit.Framework;
using UnitConverter;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters.SpecificUnitConverters.Length;

namespace TestUnitConverter
{
    public class CustomCategoryConverterTest
    {
        public Converter Converter;

        #region Category Converter

        // Base unit is liter
        private class VolumeConverter : BaseCategoryConverter
        {
            public VolumeConverter()
            {
                Converters = new Dictionary<string, ISpecificUnitConverter>()
                {
                    { "Liters", new LiterConverter() },
                    { "Pints", new PintConverter() }
                };
            }
        }

        #endregion

        #region Specific Converters

        private class LiterConverter : ISpecificUnitConverter
        {
            public string GetPluralNameForOutput => "liters";

            public double ToBase(double value)
            {
                return value;
            }

            public double FromBase(double value)
            {
                return value;
            }
        }

        private class PintConverter : ISpecificUnitConverter
        {
            public string GetPluralNameForOutput => "pints";

            // Convert pints to liters
            public double ToBase(double value)
            {
                return value * 0.473176;
            }

            // Convert liters to pints
            public double FromBase(double value)
            {
                return value / 0.473176;
            }
        }

        private class CubicinchConverter : ISpecificUnitConverter
        {
            public string GetPluralNameForOutput => "cubicinch";

            // Convert cubicinch to liters
            public double ToBase(double value)
            {
                return value * 0.016387;
            }

            // Convert liters to cubicinch
            public double FromBase(double value)
            {
                return value / 0.016387;
            }
        }

        #endregion

        [SetUp]
        public void Setup()
        {
            Converter = new Converter();
            Converter.AddCustomCategoryConverter("Volume", new VolumeConverter());
        }

        [Test]
        public void LitersToPints_100LitersToPints_211p34()
        {
            var fromValue = 100;
            var fromUnitName = "Liters";
            var toUnitName = "Pints";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("211.34 pints", result);
        }

        [Test]
        public void PintsToLiters_100PintsToLiters_47p32()
        {
            var fromValue = 100;
            var fromUnitName = "Pints";
            var toUnitName = "Liters";

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("47.32 liters", result);
        }

        public void WithCustomConverterLitersToCubicinch_1LitersToCubicinch_61p02()
        {
            var fromValue = 1;
            var fromUnitName = "Liters";
            var toUnitName = "Cubicinch";

            Converter.AddCustomConverter("Volume", new[] { "Cubicinch" }, new CubicinchConverter());

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("61.02 cubicinch", result);
        }

        [Test]
        public void WithCustomConverterCubicinchToLiters_10000CubicinchToLiters_163p87()
        {
            var fromValue = 10000;
            var fromUnitName = "Cubicinch";
            var toUnitName = "Liters";

            Converter.AddCustomConverter("Volume", new[] { "Cubicinch" }, new CubicinchConverter());

            var result = Converter.Convert($"{fromValue} {fromUnitName}", toUnitName);
            Assert.AreEqual("163.87 liters", result);
        }
    }
}
