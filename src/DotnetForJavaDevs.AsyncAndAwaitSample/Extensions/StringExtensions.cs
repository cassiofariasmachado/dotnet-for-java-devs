using System.Globalization;

namespace DotnetForJavaDevs.AsyncAndAwaitSample.Extensions
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string str)
            => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
    }
}