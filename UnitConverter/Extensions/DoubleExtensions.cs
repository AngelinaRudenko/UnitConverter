using System;
using UnitConverter.Converters.Constants;

namespace UnitConverter.Extensions
{
    internal static class DoubleExtensions
    {
        // Get value as it has no SI prefix
        internal static double ConvertFromPrefix(this double value, string prefix)
        {
            var result = prefix == null || string.IsNullOrEmpty(prefix) ? value : value * Math.Pow(10, MetricPrefixes.SIPrefixes[prefix]);
            return result;
        }

        // Apply metric SI prefix to value
        internal static double ConvertToPrefix(this double value, string prefix)
        {
            var result = prefix == null || string.IsNullOrEmpty(prefix) ? value : value / Math.Pow(10, MetricPrefixes.SIPrefixes[prefix]);
            return result;
        }
    }
}
