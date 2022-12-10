using System.Collections.Generic;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.SpecificUnitConverters.Length;

namespace UnitConverter.Converters
{
    // Base unit for length is Meter
    internal class LengthConverter : BaseCategoryOfUnitsConverter
    {
        public override Dictionary<string, ISpecificUnitConverter> Converters =>
            new Dictionary<string, ISpecificUnitConverter>()
            {
                { "Meters", new MeterLengthConverter() },
                { "Feet", new FootLengthConverter() },
                { "Foot", new FootLengthConverter() },
                { "Inches", new InchLengthConverter() }
            };
    }
}
