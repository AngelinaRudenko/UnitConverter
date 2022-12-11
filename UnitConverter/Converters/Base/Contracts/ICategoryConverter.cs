using System.Collections.Generic;
using UnitConverter.Decoder;

namespace UnitConverter.Converters.Base.Contracts
{
    public interface ICategoryConverter
    {
        // Convert value from unit to unit
        string Convert(DecodedInputDTO input);

        // Add custom converter
        void AddConverter(IEnumerable<string> possibleNames, ISpecificUnitConverter customUnitConverter);
    }
}
