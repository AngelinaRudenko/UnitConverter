using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters.Constants;
using UnitConverter.Decoder;
using UnitConverter.Extensions;

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

        public virtual string Convert(DecodedInputDTO input)
        {
            var fromValue = input.FromValue.ConvertFromPrefix(input.FromPrefix);

            var toBaseUnitConverter = GetSuitableConverter(input.FromUnit);
            var toDestinationUnitConverter = GetSuitableConverter(input.ToUnit);

            var baseValue = toBaseUnitConverter.ToBase(fromValue);
            var result = (double) toDestinationUnitConverter.FromBase(baseValue);
            result = result.ConvertToPrefix(input.ToPrefix);

            return ResultToString(result, input.ToPrefix, toDestinationUnitConverter.GetPluralNameForOutput);
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

        private string ResultToString(double value, string prefix, string unitName)
        {
            var result = Math.Round(value, 2) + " ";

            if (prefix != null)
                result += prefix;

            result += unitName;
            return result;
        }
    }
}
