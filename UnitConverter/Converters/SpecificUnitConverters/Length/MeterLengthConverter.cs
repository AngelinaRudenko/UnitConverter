using UnitConverter.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Length
{
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
