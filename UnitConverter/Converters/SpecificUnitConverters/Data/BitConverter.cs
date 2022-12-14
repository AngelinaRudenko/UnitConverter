using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.SpecificUnitConverters.Data
{
    // Base data unit
    internal class BitConverter : ISpecificUnitConverter
    {
        public string GetPluralNameForOutput => "bits";

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
