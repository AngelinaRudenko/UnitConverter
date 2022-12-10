using System.Collections.Generic;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.Enums;
using UnitConverter.Converters.Length;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Base Unit for length is Meter
    /// </summary>
    internal class LengthConverter : BaseCategoryOfUnitsConverter<LengthUnit>
    {
        public override Dictionary<string, LengthUnit> PossibleNames =>
            new Dictionary<string, LengthUnit>()
            {
                { "Meters", LengthUnit.Meter },
                { "Feet", LengthUnit.Foot },
                { "Foot", LengthUnit.Foot },
                { "Inches", LengthUnit.Inch }
            };

        public override Dictionary<LengthUnit, string> PluralNamesForOutput =>
            new Dictionary<LengthUnit, string>()
            {
                {LengthUnit.Meter, "meters"},
                {LengthUnit.Foot, "feet"},
                {LengthUnit.Inch, "inches"}
            };

        public override Dictionary<LengthUnit, ISpecificUnitConverter> Converters =>
            new Dictionary<LengthUnit, ISpecificUnitConverter>()
            {
                { LengthUnit.Meter, new MeterLengthConverter() },
                { LengthUnit.Foot, new FootLengthConverter() },
                { LengthUnit.Inch, new InchLengthConverter() }
            };
    }
}
