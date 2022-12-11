using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Temperature
{
    internal class FahrenheitConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "fahrenheit";

        // Convert fahrenheit to celsius
        public double ToBase(double value)
        {
            return (value - 32) * 5 / 9;
        }

        // Convert celsius to fahrenheit
        public double FromBase(double value)
        {
            return value * 9 / 5 + 32;
        }
    }
}
