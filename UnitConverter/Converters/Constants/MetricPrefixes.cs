using System.Collections.Generic;

namespace UnitConverter.Converters.Constants
{
    internal static class MetricPrefixes
    {
        // key = 10^value
        internal static Dictionary<string, short> SIPrefixes = new Dictionary<string, short>()
        {
            {"tera", 12 },
            {"giga", 9 },
            {"mega", 6 },
            {"kilo", 3 },
            {"hecto", 2 },
            {"deca", 1 },
            {"deci", -1 },
            {"centi", -2 },
            {"milli", -3 },
            {"micro", -6 },
            {"nano", -9 }
        };
    }
}
