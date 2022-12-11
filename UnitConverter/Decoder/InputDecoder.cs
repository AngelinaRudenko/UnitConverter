using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.Constants;
using UnitConverter.Extensions;

namespace UnitConverter.Decoder
{
    internal class InputDecoder
    {
        internal readonly Dictionary<string, BaseCategoryConverter> CategoryConverters;

        internal InputDecoder(Dictionary<string, BaseCategoryConverter> categoryConverters)
        {
            CategoryConverters = categoryConverters;
        }

        public DecodedInputDTO Decode(string rawFrom, string rawTo)
        {
            var from = DecodeFrom(rawFrom);
            var fromUnit = DecodeUnitString(from.possibleName);
            var to = DecodeUnitString(rawTo);

            if (fromUnit.categoryName != to.categoryName)
                throw new ValidationException("Impossible conversion between group of units.");

            return new DecodedInputDTO()
            {
                FromUnit = fromUnit.unitName,
                FromPrefix = fromUnit.prefix,
                ToUnit = to.unitName,
                ToPrefix = to.prefix,
                FromValue = from.value,
                CategoryConverterName = fromUnit.categoryName
            };
        }

        // Decode from
        // Returns value number and correct unit name
        private (double value, string possibleName) DecodeFrom(string from)
        {
            var text = from.Trim();

            var numberStr = Regex.Match(text, @"\d+").Value;

            if (string.IsNullOrEmpty(numberStr))
                throw new ValidationException("Input is invalid. Doesn't contain numbers.");

            var number = Convert.ToDouble(numberStr);

            var possibleName = text.RemoveFirstCharacters(numberStr.Length);

            return (number, possibleName);
        }

        // Decode unit string
        // Return unit name, SI prefix, name of unit category
        private (string unitName, string prefix, string categoryName) DecodeUnitString(string rawUnitName)
        {
            var possibleName = rawUnitName.Trim().ToLower();
            var prefix = MetricPrefixes.SIPrefixes.Keys
                .FirstOrDefault(metricPrefix => possibleName.StartsWith(metricPrefix, StringComparison.OrdinalIgnoreCase));

            if (prefix != null && !string.IsNullOrEmpty(prefix))
                possibleName = possibleName.RemoveFirstCharacters(prefix.Length);

            foreach (var categoryConverter in CategoryConverters)
            {
                var specificConverterNames = categoryConverter.Value.GetConverterNames();

                foreach (var specificConverterName in specificConverterNames)
                {
                    if (specificConverterName.Contains(possibleName, StringComparison.OrdinalIgnoreCase))
                        return (specificConverterName, prefix, categoryConverter.Key);
                }
            }

            throw new ValidationException($"Unit \"{possibleName}\" not found.");
        }
    }
}
