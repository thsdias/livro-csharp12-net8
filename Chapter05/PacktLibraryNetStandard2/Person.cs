namespace Packt.Shared;

public partial class Person
{
    public string? Name;

    public DateTimeOffset Born;

    // This has been moved to PersonAutoGen.cs as a property.
    //public WondersOfTheAncientWorld FavoriteAncientWonder;

    public WondersOfTheAncientWorld BucketList;

    public List<Person> Children = new();

    public const string Species = "Homo Sapiens";

    // Read-only fields: Values that can be set at runtime.
    public readonly string HomePlanet = "Earth";

    public readonly DateTime Instantiated;

    #region Constructors: Called when using new to instantiate a type.
    public Person()
    {
        // Constructors can set default values for fields
        // including any read-only fields like Instantiated.
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
    #endregion

    #region Methods: Actions the type can perform.
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}.";
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{name} says 'Hello, {name}!'";
    }

    public string OptionalParameters(int count, string command = "Run!", double number = 0.0, bool active = true)
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active
        );
    }
    
    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default and they
        // must be initialized inside the method.
        z = 100;

        // Increment each parameter except the read-only x.
        w++;
        y++; 
        z++;
        // x++; // Gives a compiler error!

        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");      
    }
    #endregion

    #region Tuple
    // Method that returns a tuple: (string, int).
    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    // Method that returns a tuple with named fields.
    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }    

    // Aliasing a tuple type.
    //using UnnamedParameters = (string, int);

    // Aliasing a tuple type with parameter names.
    //using Fruit = (string Name, int Number); 
    #endregion

    #region Deconstruct
    // Deconstructors: Break down this object into parts.
    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(out string? name, out DateTimeOffset dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = Born;
        fav = BucketList;
    }
    #endregion

    #region Local Functions
    // Method with a local function.
    public static int Factorial(int number)
    {
        if (number < 0)
            throw new ArgumentException($"{nameof(number)} cannot be less than zero.");

        return localFactorial(number);

        int localFactorial(int localNumber) // Local function.
        {
            if (localNumber == 0)
                return 1;

            return localNumber * localFactorial(localNumber - 1);
        }
    }
    #endregion
}