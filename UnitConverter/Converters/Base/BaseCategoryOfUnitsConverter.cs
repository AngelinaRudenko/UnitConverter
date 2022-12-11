using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters.SpecificUnitConverters.Length;

namespace UnitConverter.Converters.Base
{
    internal abstract class BaseCategoryOfUnitsConverter : ICategoryOfUnitsConverter
    {
        protected Dictionary<string, ISpecificUnitConverter> Converters;

        public Dictionary<string, ISpecificUnitConverter> GetConverters()
        {
            return Converters;
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

        public void AddCustomConverter(IEnumerable<string> possibleNames, ISpecificUnitConverter customUnitConverter)
        {
            Converters.Add("Test", new MeterLengthConverter());
            foreach (var name in possibleNames)
            {
                Converters.TryAdd(name, customUnitConverter);
            }
        }
    }
}
