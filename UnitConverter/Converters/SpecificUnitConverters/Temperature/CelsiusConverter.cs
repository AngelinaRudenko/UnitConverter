using UnitConverter.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Temperature
{
    internal class CelsiusConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "celsius";

        public double ToBase(double value)
        {
            return value;
        }

        public double FromBase(double value)
        {
            return value;
        }
    }
}
