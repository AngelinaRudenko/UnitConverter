using System.Collections.Generic;

namespace UnitConverter.Converters.Base.Contracts
{
    public interface ICategoryConverter
    {
        // Convert value from unit to unit
        string Convert(string fromUnit, string toUnit, double value);

        // Add custom converter
        void AddConverter(IEnumerable<string> possibleNames, ISpecificUnitConverter customUnitConverter);
    }
}
