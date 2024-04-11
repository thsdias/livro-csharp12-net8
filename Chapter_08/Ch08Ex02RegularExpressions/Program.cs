using System.Text.RegularExpressions;

// The default regular expression checks for at least one digit.
bool result = false;
Regex inputCheck = LeastOneDigit();

WriteLine("Enter a regular expression (or press ENTER to use the default): ^[a-z]+$");
string inputRegex = ReadLine()!;

while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey();

    if (keyInfo.Key == ConsoleKey.Escape)
    {
        break;
    }
    else 
    {
        WriteLine("Enter some input:");
        string input = ReadLine()!;

        if(string.IsNullOrEmpty(inputRegex))
        {
            result = inputCheck.IsMatch(input);
        }
        else
        {
            inputCheck = new(inputRegex);
            result = inputCheck.IsMatch(input);
        }

        WriteLine($"\nmatches ({inputCheck})? {result}");
        WriteLine("\nPress ESC to end or any key to try again.");
    }
}