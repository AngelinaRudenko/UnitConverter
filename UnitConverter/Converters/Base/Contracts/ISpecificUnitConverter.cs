namespace UnitConverter.Contracts
{
    public interface ISpecificUnitConverter
    {
        double ToBase(double value);

        double FromBase(double value);
    }
}
