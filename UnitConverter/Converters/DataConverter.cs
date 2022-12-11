
using System.Collections.Generic;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.SpecificUnitConverters.Data;

namespace UnitConverter.Converters
{
    // Base unit for data is Bit
    internal class DataConverter : BaseCategoryOfUnitsConverter
    {
        public DataConverter()
        {
            Converters = new Dictionary<string, ISpecificUnitConverter>()
            {
                { "Bits", new BitConverter() },
                { "Bytes", new ByteConverter() }
            };
        }
    }
}
