using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Decoder
{
    internal struct DecodedInputDTO
    {
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double FromValue { get; set; }
    }

    internal class InputDecoder
    {
        private readonly ICategoryOfUnitsConverter[] Converters;

        public InputDecoder(ICategoryOfUnitsConverter[] converters)
        {
            Converters = converters;
        }

        public DecodedInputDTO Decode(string rawFrom, string rawTo)
        {
            var from = DecodeFrom(rawFrom);
            var toUnit = DecodeUnitString(rawTo);

            var fromConverter = Converters
                .FirstOrDefault(x => x.GetConverters().ContainsKey(from.unit));

            var toConverter = Converters
                .FirstOrDefault(x => x.GetConverters().ContainsKey(toUnit));

            if (fromConverter?.GetType() != toConverter?.GetType())
                throw new ValidationException("Impossible conversion between group of units.");

            return new DecodedInputDTO()
            {
                FromUnit = from.unit,
                ToUnit = toUnit,
                FromValue = from.value
            };
        }

        // Decode from
        // Returns value number and correct unit name
        private (double value, string unit) DecodeFrom(string from)
        {
            var text = from.Trim();

            var numberStr = Regex.Match(text, @"\d+").Value;

            if (string.IsNullOrEmpty(numberStr))
                throw new ValidationException("Input is invalid. Doesn't contain numbers.");

            var number = Convert.ToDouble(numberStr);

            var cutInputStartIndex = text.IndexOf(numberStr, StringComparison.Ordinal) + numberStr.Length;
            var unitStr = text.Substring(cutInputStartIndex, text.Length - cutInputStartIndex);

            var unitName = DecodeUnitString(unitStr);

            return (number, unitName);
        }

        private string DecodeUnitString(string rawUnitName)
        {
            var possibleName = rawUnitName.Trim();

            foreach (var categoryOfUnitConverter in Converters)
            {
                var correctUnitName = categoryOfUnitConverter.GetConverters().Keys
                    .FirstOrDefault(x => x.Contains(possibleName, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrEmpty(correctUnitName))
                    return correctUnitName;
            }

            throw new ValidationException($"Unit \"{possibleName}\" not found.");
        }
    }
}
