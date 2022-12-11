using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Temperature
{
    // Base temperature unit
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
