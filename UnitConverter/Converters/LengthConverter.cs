using System.Collections.Generic;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters.SpecificUnitConverters.Length;

namespace UnitConverter.Converters
{
    // Base unit for length is Meter
    internal class LengthConverter : BaseCategoryConverter
    {
        public LengthConverter()
        {
            Converters = new Dictionary<string, ISpecificUnitConverter>()
            {
                { "Meters", new MeterLengthConverter() },
                { "Feet", new FootLengthConverter() },
                { "Foot", new FootLengthConverter() },
                { "Inches", new InchLengthConverter() }
            };
        }
    }
}
