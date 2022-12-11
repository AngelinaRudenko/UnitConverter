using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Length
{
    internal class InchLengthConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "inches";

        // Convert inches to meters
        public double ToBase(double value)
        {
            return value * 0.0254;
        }

        // Convert meters to inches
        public double FromBase(double value)
        {
            return value / 0.0254;
        }
    }
}
