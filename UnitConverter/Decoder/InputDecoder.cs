using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using UnitConverter.Converters;

namespace UnitConverter.Decoder
{
    internal class InputDecoder
    {
        // Decode from
        // Returns value number and unit
        public Tuple<double, string> DecodeFrom(string from)
        {
            var text = from.Trim();

            var numberStr = Regex.Match(text, @"\d+").Value;

            if (string.IsNullOrEmpty(numberStr))
                throw new ValidationException("Input is not valid. Doesn't contain numbers.");

            var number = Convert.ToDouble(numberStr);

            var cutInputStartIndex = text.IndexOf(numberStr, StringComparison.Ordinal) + numberStr.Length;
            var unitStr = text.Substring(cutInputStartIndex, text.Length - cutInputStartIndex);

            var unitName = DecodeUnitString(unitStr);

            return new Tuple<double, string>(number, unitName);
        }

        public string DecodeUnitString(string text)
        {
            var lengthConverter = new LengthConverter();

            var unitName = lengthConverter.PossibleNames.Keys
                .FirstOrDefault(x =>
                    x.Contains(text.Trim(), StringComparison.OrdinalIgnoreCase));

            return unitName;
        }
    }
}
