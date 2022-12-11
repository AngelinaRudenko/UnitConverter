using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using UnitConverter.Converters.Base;

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
            var to = DecodeUnitString(rawTo);

            if (from.categoryName != to.categoryName)
                throw new ValidationException("Impossible conversion between group of units.");

            return new DecodedInputDTO()
            {
                FromUnit = from.unitName,
                ToUnit = to.unitName,
                FromValue = from.value,
                CategoryConverterName = from.categoryName
            };
        }

        // Decode from
        // Returns value number and correct unit name
        private (double value, string unitName, string categoryName) DecodeFrom(string from)
        {
            var text = from.Trim();

            var numberStr = Regex.Match(text, @"\d+").Value;

            if (string.IsNullOrEmpty(numberStr))
                throw new ValidationException("Input is invalid. Doesn't contain numbers.");

            var number = Convert.ToDouble(numberStr);

            var cutInputStartIndex = text.IndexOf(numberStr, StringComparison.Ordinal) + numberStr.Length;
            var unitStr = text.Substring(cutInputStartIndex, text.Length - cutInputStartIndex);

            var unit = DecodeUnitString(unitStr);

            return (number, unit.unitName, unit.categoryName);
        }

        private (string unitName, string categoryName) DecodeUnitString(string rawUnitName)
        {
            var possibleName = rawUnitName.Trim();

            foreach (var categoryConverter in CategoryConverters)
            {
                var specificConverterNames = categoryConverter.Value.GetConverterNames();

                foreach (var specificConverterName in specificConverterNames)
                {
                    if (specificConverterName.Contains(possibleName))
                        return (specificConverterName, categoryConverter.Key);
                }
            }

            throw new ValidationException($"Unit \"{possibleName}\" not found.");
        }
    }
}
