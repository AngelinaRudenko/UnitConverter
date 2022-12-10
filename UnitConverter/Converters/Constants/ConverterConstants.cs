using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.Constants
{
    internal static class ConverterConstants
    {
        internal static ICategoryOfUnitsConverter[] Converters =
        {
            new LengthConverter(),
            new DataConverter(),
            new TemperatureConverter()
        };
    }
}
