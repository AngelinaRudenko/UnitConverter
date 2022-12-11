
using System.Collections.Generic;
using UnitConverter.Converters.Base;
using UnitConverter.Converters.Base.Contracts;
using UnitConverter.Converters.SpecificUnitConverters.Data;

namespace UnitConverter.Converters
{
    // Base unit for data is Bit
    internal class DataConverter : BaseCategoryConverter
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
