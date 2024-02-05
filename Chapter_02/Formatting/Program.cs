using static System.Console;

int numberOfApples = 12;
decimal pricePerApple = 0.35M;

Formatting();
InterpolatedStrings();
AlignmentValues();
GettingTextInput();
GettingTextInputII();

void Formatting()
{
    WriteLine(
        format: "{0} apples cost {1:c}",
        arg0: numberOfApples,
        arg1: pricePerApple * numberOfApples
    );

    // Three parameter values can use named arguments.
    WriteLine(
        "{0} {1} lived in {2}.", 
        arg0: "Roger", arg1: "Cevung", arg2: "Stockholm"
    );

    // Four or more parameter values cannot use named arguments.
    WriteLine(
        "{0} {1} lived in {2} and worked in the {3} team at {4}.", 
        "Roger", "Cevung", "Stockholm", "Education", "Optimizely"
    );
}

void InterpolatedStrings()
{
    // The following statement must be all on one line when using C# 10
    // or earlier. If using C# 11 or later, we can include a line break
    // in the middle of an expression but not in the string text.
    WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");
}

void AlignmentValues()
{
    // An N0 format string means a number with thousand separators and no decimal places, 
    // while a C format string means currency. The currency format will be determined by the current thread.

    string applesText = "Apples"; 
    int applesCount = 1234;
    string bananasText = "Bananas"; 
    int bananasCount = 56789;

    WriteLine();
    WriteLine(
        format: "{0,-10} {1,6}",
        arg0: "Name", arg1: "Count");
    
    WriteLine(
        format: "{0,-10} {1,6:N0}",
        arg0: applesText, arg1: applesCount);
    
    WriteLine(
        format: "{0,-10} {1,6:N0}",
        arg0: bananasText, arg1: bananasCount);

    WriteLine(
        format: "{0,-10} {1,6:C0}",
        arg0: bananasText, arg1: bananasCount);
} 

void GettingTextInput()
{
    Write("Type your first name and press ENTER: "); 
    string? firstName = ReadLine();
    Write("Type your age and press ENTER: "); 
    string age = ReadLine()!;
    WriteLine($"Hello {firstName}, you look good for {age}.");
}

void GettingTextInputII()
{
    Write("Press any key combination: "); 
    ConsoleKeyInfo key = ReadKey(); 
    WriteLine();
    WriteLine(
        "Key: {0}, Char: {1}, Modifiers: {2}",
        arg0: key.Key, arg1: key.KeyChar, arg2: key.Modifiers);
}