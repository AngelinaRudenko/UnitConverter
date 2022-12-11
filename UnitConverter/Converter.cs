using System.Collections.Generic;
using System.Linq;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters;
using UnitConverter.Decoder;
using UnitConverter.Converters.Enum;

namespace UnitConverter
{
    public class Converter
    {
        private readonly ICategoryOfUnitsConverter[] Converters;

        public Converter()
        {
            Converters = new ICategoryOfUnitsConverter[]
            {
                new LengthConverter(),
                new DataConverter(),
                new TemperatureConverter()
            };
        }

        public string Convert(string from, string to)
        {
            var inputDecoder = new InputDecoder(Converters);
            var decodedInput = inputDecoder.Decode(from, to);

            var converter = Converters
                .FirstOrDefault(x => x.GetConverters().ContainsKey(decodedInput.ToUnit));

            var result = converter.Convert(decodedInput.FromUnit, decodedInput.ToUnit, decodedInput.FromValue);

            return result;
        }

        public void AddCustomConverter(
            ConverterCategory converterCategory,
            IEnumerable<string> possibleNames,
            ISpecificUnitConverter specificUnitConverter)
        {
            Converters[(int)converterCategory - 1].AddCustomConverter(possibleNames, specificUnitConverter);
        }
    }
}
