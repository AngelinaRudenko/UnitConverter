using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Converts from unit to unit.
        /// </summary>
        /// <param name="from">String contains number value and name of specific source unit.</param>
        /// <param name="to">String contains specific destination nit.</param>
        /// <returns></returns>
        public string Convert(string from, string to)
        {
            var inputDecoder = new InputDecoder(CategoryConverters);
            var decodedInput = inputDecoder.Decode(from, to);

            var result = CategoryConverters[decodedInput.CategoryConverterName].Convert(decodedInput);

            return result;
        }

        /// <summary>
        /// Add custom converter.
        /// </summary>
        /// <param name="converterCategoryName">Converter category name.</param>
        /// <param name="possibleNames">Custom specific converter possible names.</param>
        /// <param name="specificUnitConverter">Specific unit converter.</param>
        public void AddCustomConverter(
            string converterCategoryName,
            IEnumerable<string> possibleNames,
            ISpecificUnitConverter specificUnitConverter)
        {
            try
            {
                CategoryConverters[converterCategoryName].AddConverter(possibleNames, specificUnitConverter);
            }
            catch (KeyNotFoundException ex)
            {
                throw new NotImplementedException($"Converter category \"{converterCategoryName}\" does not exist.");
            }
        }

        /// <summary>
        /// Add custom category converter.
        /// </summary>
        /// <param name="converterCategoryName">Converter category name.</param>
        /// <param name="categoryConverter">Category converter.</param>
        public void AddCustomCategoryConverter(
            string converterCategoryName,
            BaseCategoryConverter categoryConverter)
        {
            CategoryConverters.Add(converterCategoryName, categoryConverter);
        }
    }
}
