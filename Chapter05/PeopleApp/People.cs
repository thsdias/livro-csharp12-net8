using System.ComponentModel.Design;
using System.Data;
using Packt.Shared;

using Fruit = (string Name, int Number); // Aliasing a tuple type with parameter names.

public class People
{
    public People()
    {
        Person bob = new();
        WriteLine(bob);

        bob.Name = "Bob Smith";
        bob.Born = new DateTimeOffset(
            year: 1965, month: 12, day: 22,
            hour: 16, minute: 28, second: 0,
            offset: TimeSpan.FromHours(-5)
        );

        WriteLine(format: "{0} was born on {1:D}", arg0: bob.Name, arg1: bob.Born);

        /*
        bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

        WriteLine(
            format: "{0}'s favorite wonder is {1}. Its integer is {2}",
            arg0: bob.Name,
            arg1: bob.FavoriteAncientWonder,
            arg2: (int)bob.FavoriteAncientWonder
        );
        */

        bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
                        | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
        // bob.BucketList = (WondersOfTheAncientWorld)18;
        WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

        bob.Children.Add(new Person { Name = "Alfred" });
        bob.Children.Add(new Person { Name = "Bella" });
        bob.Children.Add(new Person { Name = "Zoe" });

        WriteLine($"{bob.Name} has {bob.Children.Count} children:");

        foreach (var child in bob.Children)
        {
            WriteLine($"> {child.Name}");
        }

        WriteLine();

        Person alice = new()
        {
            Name = "Alice Jones",
            Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
        };

        WriteLine(format: "{0} was born on {1:d}", arg0: alice.Name, arg1: alice.Born);

        WriteLine();

        // Constant fields are accessible via the type.
        WriteLine($"{bob.Name} is a {Person.Species}.");

        // Read-only fields are accessible via the variable.
        WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");
        
        WriteLine();

        Person blankPerson = new();
        WriteLine(format:
                    "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                    arg0: blankPerson.Name,
                    arg1: blankPerson.HomePlanet,
                    arg2: blankPerson.Instantiated);

        WriteLine();

        Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
        WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: gunny.Name,
            arg1: gunny.HomePlanet,
            arg2: gunny.Instantiated);

        WriteLine();

        bob.WriteToConsole();
        WriteLine(bob.GetOrigin());

        WriteLine();

        WriteLine(bob.SayHello());
        WriteLine(bob.SayHello("Emily"));

        WriteLine();

        WriteLine(bob.OptionalParameters(3));
        WriteLine(bob.OptionalParameters(3, "Jump!", 98.5));
        WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!", count: 3));
        WriteLine(bob.OptionalParameters(3, "Poke!", active: false));

        WriteLine();

        int a = 10; 
        int b = 20; 
        int c = 30;
        int d = 40;

        WriteLine($"Before: a={a}, b={b}, c={c}, d={d}"); 
        bob.PassingParameters(a, b, ref c, out d);
        WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

        WriteLine();

        int e = 50;
        int f = 60;
        int g = 70;
        
        WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");
        
        // Simplified C# 7 or later syntax for the out parameter.
        bob.PassingParameters(e, f, ref g, out int h);
        WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

        #region Tuple
        SetTitle("TUPLES");

        (string, int) fruit = bob.GetFruit();
        WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

        var fruitNamed = bob.GetNamedFruit();
        WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

        // Tuple name inference.
        var thing1 = ("Neville", 4);
        WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

        var thing2 = (bob.Name, bob.Children.Count);
        WriteLine($"{thing2.Name} has {thing2.Count} children.");

        // With an aliased tuple type.
        Fruit fruitNamed3 = bob.GetNamedFruit();
        WriteLine($"Aliased tuple type FruitNamed3: {fruitNamed3.Number} {fruitNamed3.Name}.");

        // Store return value in a tuple variable with two named fields.
        (string name, int number) namedFields = bob.GetNamedFruit();
        WriteLine($"{namedFields.name}, {namedFields.number}"); // You can then access the named fields.

        // Deconstruct the return value into two separate variables.
        (string name, int number) = bob.GetNamedFruit();
        WriteLine($"{name}, {number}"); // You can then access the separate variables.

        (string fruitName, int fruitNumber) = bob.GetFruit();
        WriteLine($"Deconstructed tuple: {fruitName}, {fruitNumber}");
        #endregion

        #region Deconstruct Method
        SetTitle("DECONSTRUCT");

        var (name1, dob1) = bob;    // Implicitly calls the Deconstruct method.
        WriteLine($"Deconstructed person: {name1}, {dob1}");

        var (name2, dob2, fav2) = bob;
        WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");
        #endregion

        #region Local Functions
        SetTitle("Local Functions");

        number = -5;

        try
        {
            WriteLine($"Factorial {number}! is {Person.Factorial(number)}");
        }
        catch (Exception ex)
        {
            WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}");
        }
        #endregion

        #region Read-only Properties
        SetTitle("Read-only Properties");

        Person sam = new()
        {
            Name = "Sam",
            Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
        };

        WriteLine(sam.Origin);
        WriteLine(sam.Greeting);
        WriteLine(sam.Age);
        #endregion

        #region Settable properties
        SetTitle("Settable properties");

        sam.FavoriteIceCream = "Chocolate Fudge";
        WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");

        string color = "Red";
        //string color = "White";
        try
        {
            sam.FavoritePrimaryColor = color;
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
        }
        catch(Exception ex)
        {
            WriteLine("Tried to set {0} to '{1}': {2}", nameof(sam.FavoritePrimaryColor), color, ex.Message);
        }
        #endregion

        #region Limiting flags enum values
        SetTitle("Limiting flags enum values");

        // Return exception 1.
        /*
        bob.FavoriteAncientWonder = 
            WondersOfTheAncientWorld.StatueOfZeusAtOlympia |
            WondersOfTheAncientWorld.GreatPyramidOfGiza;
        */

        // Return exception 2.
        //bob.FavoriteAncientWonder = (WondersOfTheAncientWorld)128;

        bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
        WriteLine($"Bob’s favorite wonder: {bob.FavoriteAncientWonder}");
        #endregion

        #region Indexers
        SetTitle("Indexers");

        sam.Children.Add(new() { Name = "Charlie", Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero) });
        sam.Children.Add(new() { Name = "Ella", Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero) });

        // Get using Children list.
        WriteLine($"Sam's first child is {sam.Children[0].Name}.");
        WriteLine($"Sam's second child is {sam.Children[1].Name}.");

        // Get using the int indexer.
        WriteLine($"Sam's first child is {sam[0].Name}.");
        WriteLine($"Sam's second child is {sam[1].Name}.");

        // Get using the string indexer.
        WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old");
        #endregion
    }

    internal static void SetTitle(string title)
    {
        WriteLine();
        WriteLine($":::::::::::::::: {title} :::::::::::::::: ");
        WriteLine();
    }
}