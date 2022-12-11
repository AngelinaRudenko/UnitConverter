using System.Collections.Generic;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters.SpecificUnitConverters.Temperature;

namespace UnitConverter.Converters
{
    // Base unit for temperature is Celsius
    internal class TemperatureConverter : BaseCategoryConverter
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
