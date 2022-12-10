using UnitConverter.Contracts;

namespace UnitConverter.Converters.Length
{
    internal class InchLengthConverter : ISpecificUnitConverter
    {
        // Convert inches to meters
        public double ToBase(double value)
        {
            var meters = value * 0.0254;
            return meters;
        }

        // Convert meters to inches
        public double FromBase(double value)
        {
            var inches = value / 0.0254;
            return inches;
        }
    }
}
