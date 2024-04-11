
#region Using indexes, ranges, and spans
PrintTitle("Using indexes, ranges, and spans");

string name = "Samantha Jones";

// Getting the lengths of the first and last names.
int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

// Using Substring.
string firstName = name.Substring(startIndex: 0, length: lengthOfFirst);
string lastName = name.Substring(startIndex: name.Length - lengthOfLast, length: lengthOfLast);
WriteLine($"First: {firstName}, Last: {lastName}");

// Using spans.
ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..];
WriteLine($"First: {firstNameSpan}, Last: {lastNameSpan}");
#endregion

WriteLine();

static void PrintTitle(string title)
{
    WriteLine();
    WriteLine($"{new string(':', 28)} {title} {new string(':', 28)}");
    WriteLine();
}