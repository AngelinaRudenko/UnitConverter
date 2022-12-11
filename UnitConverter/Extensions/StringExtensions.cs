namespace UnitConverter.Extensions
{
    internal static class StringExtensions
    {
        // Remove first <removeCharactersCount> characters from string
        internal static string RemoveFirstCharacters(this string value, int removeCharactersCount)
        {
            return value.Remove(0, removeCharactersCount);
        }
    }
}
