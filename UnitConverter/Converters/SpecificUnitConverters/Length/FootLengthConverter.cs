using UnitConverter.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Length
{
    internal class FootLengthConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "feet";

        // Convert feet to meters
        public double ToBase(double value)
        {
            return value / 3.2808399;
        }

        // Convert meters to feet
        public double FromBase(double value)
        {
            return value * 3.2808399;
        }
    }
}
