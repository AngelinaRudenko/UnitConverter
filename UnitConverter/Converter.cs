using System.Linq;
using UnitConverter.Converters.Constants;
using UnitConverter.Decoder;

namespace UnitConverter
{
    public class Converter
    {
        private readonly InputDecoder InputDecoder;

        public Converter()
        {
            InputDecoder = new InputDecoder();
        }

        public string Convert(string from, string to)
        {
            var decodedInput = InputDecoder.Decode(from, to);

            var converter = ConverterConstants.Converters.FirstOrDefault(
                x => x.Converters.ContainsKey(decodedInput.ToUnit));

            var result = converter.Convert(decodedInput.FromUnit, decodedInput.ToUnit, decodedInput.FromValue);

            return result;
        }
    }
}
