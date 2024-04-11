
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

partial class Program
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string RegexLeastOneDigit = "^[a-z]+$";

    [GeneratedRegex(RegexLeastOneDigit, RegexOptions.IgnoreCase)]
    private static partial Regex LeastOneDigit();
}