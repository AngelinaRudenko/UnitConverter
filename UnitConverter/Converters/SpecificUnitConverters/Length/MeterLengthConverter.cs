using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Length
{
    // Base length unit
    internal class MeterLengthConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "meters";

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
