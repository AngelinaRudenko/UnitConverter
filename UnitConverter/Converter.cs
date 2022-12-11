using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters;
using UnitConverter.Decoder;
using UnitConverter.Converters.Base;

namespace UnitConverter
{
    public class Converter
    {
        private readonly Dictionary<string, BaseCategoryConverter> CategoryConverters;

        public Converter()
        {
            CategoryConverters = new Dictionary<string, BaseCategoryConverter>
            {
                { "Length", new LengthConverter() },
                { "Data", new DataConverter() },
                { "Temperature", new TemperatureConverter() }
            };
        }

        public string Convert(string from, string to)
        {
            var inputDecoder = new InputDecoder(CategoryConverters);
            var decodedInput = inputDecoder.Decode(from, to);

            var result = CategoryConverters[decodedInput.CategoryConverterName].Convert(decodedInput);

            return result;
        }

        public void AddCustomConverter(
            string converterCategoryName,
            IEnumerable<string> possibleNames,
            ISpecificUnitConverter specificUnitConverter)
        {
            CategoryConverters[converterCategoryName].AddConverter(possibleNames, specificUnitConverter);
        }

        public void AddCustomCategoryConverter(
            string converterCategoryName,
            BaseCategoryConverter categoryConverter)
        {
            CategoryConverters.Add(converterCategoryName, categoryConverter);
        }
    }
}
