using System;
using System.ComponentModel.DataAnnotations;
using UnitConverter.Converters;
using UnitConverter.Decoder;

namespace UnitConverter
{
    public class Converter
    {
        private InputDecoder InputDecoder;

        public Converter()
        {
            InputDecoder = new InputDecoder();
        }

        public string Convert(string from, string to)
        {
            /*
             * TODO: Make static
             */

            var fromDecoded = InputDecoder.DecodeFrom(from);
            var toDecoded = InputDecoder.DecodeUnitString(to);

            if (string.IsNullOrEmpty(fromDecoded.Item2))
                throw new ValidationException("Unit not found.");

            var lengthConverter = new LengthConverter();

            var unitFrom = lengthConverter.PossibleNames[fromDecoded.Item2];
            var unitTo = lengthConverter.PossibleNames[toDecoded];

            var result = lengthConverter.Convert(unitFrom, unitTo, fromDecoded.Item1);

            return Math.Round(result, 2) + " " + lengthConverter.PluralNamesForOutput[unitTo];
        }
    }
}
