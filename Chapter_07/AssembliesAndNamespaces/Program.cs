using System.Xml.Linq;  // To use XDocument.
using System;   // To use String.
using Packt.Shared;

#region Relating C# keywords to .NET types
PrintTitle("Relating C# keywords to .NET types");

XDocument doc = new();
string s1 = "Hello";
String s2 = "World";
WriteLine($"{s1} {s2}");
#endregion

#region Understanding native-sized integers
PrintTitle("Understanding native-sized integers");

WriteLine($"Environment.Is64BitProcess = {Environment.Is64BitProcess}");
WriteLine($"int.MaxValue = {int.MaxValue:N0}");
WriteLine($"nint.MaxValue = {nint.MaxValue:N0}");
#endregion

#region Testing your class library package
PrintTitle("Testing your class library package");

Write("Enter a color value in hex: ");
string? hex = ReadLine();
WriteLine("Is {0} a vlid color value? {1}", arg0: hex, arg1: hex.IsValidHex());

Write("Enter a XML element: ");
string? xmlTag = ReadLine();
WriteLine("Is {0} a valid XML element? {1}", arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());

Write("Enter a password: ");
string? password = ReadLine();
WriteLine("Is {0} a valid password? {1}", arg0: password, arg1: password.IsValidPassword());
#endregion

WriteLine();

static void PrintTitle(string title)
{
    WriteLine();
    WriteLine($":::::::::::::::::::::::::::: {title} ::::::::::::::::::::::::::::");
    WriteLine();
}
