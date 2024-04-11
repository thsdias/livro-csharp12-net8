﻿using System.Text.RegularExpressions; // To use Regex.

#region Checking for digits entered as text
PrintTitle("Checking for digits entered as text");

Write("Enter your age: ");
string input = ReadLine()!; // Null-forgiving operator.

//Regex ageChecker = new(DigitsOnlyText);
Regex ageChecker = DigitsOnly();

WriteLine(ageChecker.IsMatch(input) ? "Thank you!" : $"This is not a valid age: {input}");
#endregion

#region Splitting a complex comma-separated string
PrintTitle("Splitting a complex comma-separated string");

// C# 1 to 10: Use escaped double-quote characters \"
// string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
// C# 11 or later: Use """ to start and end a raw string literal
string films = """
    "Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
    """;

WriteLine($"Films to split: {films}");
WriteLine();

string[] filmsDumb = films.Split(',');
WriteLine("Splitting with string.Split method:"); 

foreach (string film in filmsDumb)
{
    WriteLine($"  {film}");
}

WriteLine();

//Regex csv = new(CommaSeparatorText);
Regex csv = CommaSeparator();

MatchCollection filmsSmart = csv.Matches(films);

WriteLine("Splitting with regular expression:"); 

foreach (Match film in filmsSmart)
{
    WriteLine($"  {film.Groups[2].Value}");
}
#endregion

WriteLine();

static void PrintTitle(string title)
{
    WriteLine();
    WriteLine($"{new string(':', 28)} {title} {new string(':', 28)}");
    WriteLine();
}