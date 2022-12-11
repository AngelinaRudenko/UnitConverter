using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.Base
{
    public abstract class BaseCategoryConverter : ICategoryConverter
    {
        // Pairs of possible unit names and their converters
        protected Dictionary<string, ISpecificUnitConverter> Converters;

        public string[] GetConverterNames()
        {
            return Converters.Keys.ToArray();
        }

        public virtual string Convert(string fromUnit, string toUnit, double value)
        {
            var toBaseUnitConverter = GetSuitableConverter(fromUnit);
            var toDestinationUnitConverter = GetSuitableConverter(toUnit);

            var baseValue = toBaseUnitConverter.ToBase(value);
            var result = toDestinationUnitConverter.FromBase(baseValue);

            return Math.Round(result, 2) + " " + toDestinationUnitConverter.GetPluralNameForOutput;
        }

        protected ISpecificUnitConverter GetSuitableConverter(string unitName)
        {
            var correctUnitName = Converters.Keys
                .FirstOrDefault(x => x.Contains(unitName, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(correctUnitName))
                throw new NotImplementedException($"Converter for unit type \"{unitName}\" is not implemented.");

            return Converters[correctUnitName];
        }

        public void AddConverter(IEnumerable<string> possibleNames, ISpecificUnitConverter customUnitConverter)
        {
            foreach (var name in possibleNames)
            {
                Converters.Add(name, customUnitConverter);
            }
        }
    }
}
