using System.Xml;

/*
    int population = 67_000_000; // 67 million in UK.
    double weight = 1.88; // in kilograms.
    decimal price = 4.99M; // in pounds sterling.
    string fruit = "Apples"; // string values use double-quotes.
    char letter = 'Z'; // char values use single-quotes.
    bool happy = true; // Booleans can only be true or false.

    // Suffix:
    - L: Compiler infers long
    - UL: Compiler infers ulong
    - M: Compiler infers decimal
    - D: Compiler infers double
    - F: Compiler infers float

    // In Program.cs.
    Person kim = new();
    kim.BirthDate = new(1967, 12, 26); // i.e. new DateTime(1967, 12, 26)
    // In a separate Person.cs file or at the bottom of Program.cs.
    class Person
    {
    public DateTime BirthDate;
    }

    List<Person> people = new() // Instead of: new List<Person>()
    {
    new() { FirstName = "Alice" }, // Instead of: new Person() { ... }
    new() { FirstName = "Bob" },
    new() { FirstName = "Charlie" }
    };
*/

ObjectType();
DynamicType();
XmlDocument();
DefaultValuesForTypes();

void ObjectType()
{
    object height = 1.88; // Storing a double in an object.
    object name = "Amir"; // Storing a string in an object.
    Console.WriteLine($"{name} is {height} metres tall.");

    //int length1 = name.Length; // This gives a compile error!
    int length2 = ((string)name).Length; // Cast name to a string.
    Console.WriteLine($"{name} has {length2} characters.");
}

void DynamicType()
{
    dynamic something;
    
    // Storing an array of int values in a dynamic object.
    // An array of any type has a Length property.
    something = new[] { 3, 5, 7 };

    // Storing an int in a dynamic object.
    // int does not have a Length property.
    something = 12;

    // Storing a string in a dynamic object.
    // string has a Length property.
    something = "Ahmed";

    // This compiles but might throw an exception at run-time.
    Console.WriteLine($"The length of something is {something.Length}");

    // Output the type of the something variable.
    Console.WriteLine($"something is a {something.GetType()}");
}

void XmlDocument()
{
    // Good use of var because it avoids the repeated type
    // as shown in the more verbose second statement.
    var xml1 = new XmlDocument(); // Works with C# 3 and later.
    XmlDocument xml2 = new XmlDocument(); // Works with all C# versions.

    // Bad use of var because we cannot tell the type, so we
    // should use a specific type declaration as shown in
    // the second statement.
    var file1 = File.CreateText("something1.txt"); 
    StreamWriter file2 = File.CreateText("something2.txt");
}

void DefaultValuesForTypes()
{
    Console.WriteLine($"default(int) = {default(int)}");
    Console.WriteLine($"default(bool) = {default(bool)}"); 
    Console.WriteLine($"default(DateTime) = {default(DateTime)}"); 
    Console.WriteLine($"default(string) = {default(string)}");
    Console.WriteLine();

    int number = 13;
    Console.WriteLine($"number set to: {number}");
    number = default;
    Console.WriteLine($"number reset to its default: {number}");
}
