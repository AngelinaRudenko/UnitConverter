using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.Base
{
    internal abstract class BaseCategoryOfUnitsConverter : ICategoryOfUnitsConverter
    {
        public abstract Dictionary<string, ISpecificUnitConverter> Converters { get; }

        public virtual string Convert(string fromUnit, string toUnit, double value)
        {
            var toBaseUnitConverter = GetSuitableConverter(fromUnit);
            var toDestinationUnitConverter = GetSuitableConverter(toUnit);

            var baseValue = toBaseUnitConverter.ToBase(value);
            var result = toDestinationUnitConverter.FromBase(baseValue);

            return Math.Round(result, 2) + " " + toDestinationUnitConverter.GetPluralNameForOutput;
        }

        protected ISpecificUnitConverter GetSuitableConverter(string rawUnitName)
        {
            var possibleName = rawUnitName.Trim();
            var correctUnitName = Converters.Keys
                .FirstOrDefault(x => x.Contains(possibleName, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(correctUnitName))
                throw new NotImplementedException($"Converter for unit type \"{rawUnitName}\" is not implemented.");

            return Converters[correctUnitName];
        }
    }
}
