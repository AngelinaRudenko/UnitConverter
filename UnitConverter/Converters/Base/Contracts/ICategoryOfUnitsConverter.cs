using System;
using System.Collections.Generic;
using UnitConverter.Contracts;

namespace UnitConverter.Converters.Base.Contracts
{
    internal interface ICategoryOfUnitsConverter<TUnitEnum> where TUnitEnum : Enum
    {
        // Pairs of possible unit names and their enum types
        Dictionary<string, TUnitEnum> PossibleNames { get; }

        // Pairs of enum types and their plural names for output
        Dictionary<TUnitEnum, string> PluralNamesForOutput { get; }

        // Pairs of possible unit types and their converters
        Dictionary<TUnitEnum, ISpecificUnitConverter> Converters { get; }

        // Convert value from unit to unit
        double Convert(TUnitEnum fromUnit, TUnitEnum toUnit, double value);

        // Does the unit belongs to category
        // Return true if belongs
        bool Contains(string unitPossibleName);

        // Get unit type by possible name
        TUnitEnum GetTypeByPossibleName(string unitPossibleName);
    }
}
