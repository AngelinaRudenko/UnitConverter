using UnitConverter.Contracts;

namespace UnitConverter.Converters.Length
{
    internal class MeterLengthConverter : ISpecificUnitConverter
    {
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
