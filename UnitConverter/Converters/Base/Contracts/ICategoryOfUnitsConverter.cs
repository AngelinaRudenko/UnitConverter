using System.Collections.Generic;
using UnitConverter.Contracts;

namespace UnitConverter.Converters.Base.Contracts
{
    internal interface ICategoryOfUnitsConverter
    {
        // Pairs of possible unit names and their converters
        Dictionary<string, ISpecificUnitConverter> GetConverters();

        // Convert value from unit to unit
        string Convert(string fromUnit, string toUnit, double value);

        // Add custom converter
        void AddCustomConverter(IEnumerable<string> possibleNames, ISpecificUnitConverter customUnitConverter);
    }
}
