using System.Collections.Generic;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.SpecificUnitConverters.Temperature;

namespace UnitConverter.Converters
{
    // Base unit for temperature is Celsius
    internal class TemperatureConverter : BaseCategoryOfUnitsConverter
    {
        public TemperatureConverter()
        {
            Converters = new Dictionary<string, ISpecificUnitConverter>()
            {
                {"Celsius", new CelsiusConverter()},
                {"Fahrenheit", new FahrenheitConverter()}
            };
        }
    }
}
