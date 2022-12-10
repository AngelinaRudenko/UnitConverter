namespace UnitConverter.Contracts
{
    public interface ISpecificUnitConverter
    {
        string GetPluralNameForOutput { get; }

        // Convert to base unit
        double ToBase(double value);

        // Convert from base unit
        double FromBase(double value);
    }
}
