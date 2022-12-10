using UnitConverter.Contracts;

namespace UnitConverter.Converters.Length
{
    internal class FootLengthConverter : ISpecificUnitConverter
    {
        // Convert feet to meters
        public double ToBase(double value)
        {
            var meters = value / 3.2808399;
            return meters;
        }

        // Convert meters to feet
        public double FromBase(double value)
        {
            var feet = value * 3.2808399;
            return feet;
        }
    }
}
