using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Contracts;
using UnitConverter.Converters.Base.Contracts;

namespace UnitConverter.Converters.Base
{
    internal abstract class BaseCategoryOfUnitsConverter<TUnitEnum> : ICategoryOfUnitsConverter<TUnitEnum> where TUnitEnum : Enum
    {
        public abstract Dictionary<string, TUnitEnum> PossibleNames { get; }

        public abstract Dictionary<TUnitEnum, string> PluralNamesForOutput { get; }

        public abstract Dictionary<TUnitEnum, ISpecificUnitConverter> Converters { get; }

        public virtual double Convert(TUnitEnum fromUnit, TUnitEnum toUnit, double value)
        {
            // TODO: handle errors
            var baseValue = Converters[fromUnit].ToBase(value);
            var result = Converters[toUnit].FromBase(baseValue);
            return result;
        }

        public virtual bool Contains(string unitPossibleName)
        {
            unitPossibleName = unitPossibleName.Trim();
            var possibleName = PossibleNames.Keys
                .FirstOrDefault(x => x.Contains(unitPossibleName));

            return !string.IsNullOrEmpty(possibleName);
        }

        public virtual TUnitEnum GetTypeByPossibleName(string unitPossibleName)
        {
            // TODO: handle errors
            return PossibleNames[unitPossibleName];
        }
    }
}
