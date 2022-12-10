using UnitConverter.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Data
{
    internal class ByteConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "bytes";

        // Convert bytes to bits
        public double ToBase(double value)
        {
            return value * 8;
        }

        // Convert bits to bytes
        public double FromBase(double value)
        {
            return value / 8;
        }
    }
}
