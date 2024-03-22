using System.Reflection.PortableExecutable;
using Packt.Shared;

EnvironmentTest environmentTest = new();
ConfigureConsole();
ConfigureConsole(useComputerCulture: true);
//ConfigureConsole(culture: "fr-FR");
//ConfigureConsole(culture: "pt-BR");
WriteLine();

People people = new();
WriteLine();

WriteLine(":::::::::::::::: Required fields with a constructor :::::::::::::::: ");
WriteLine();
// Instantiate a book using object initializer syntax.
/*
Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
};
*/

Book book = new(isbn: "978-1803237800",
                title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
    Author = "Mark J. Price",
    PageCount = 821
};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.", 
    book.Isbn, book.Title, book.Author, book.PageCount);

WriteLine();

WriteLine(":::::::::::::::: Making a field static :::::::::::::::: ");
WriteLine();

Bank bank = new();
WriteLine();

WriteLine(":::::::::::::::: Pattern matching with objects :::::::::::::::: ");
WriteLine();

// An array containing a mix of passenger types.
Passenger[] passengers = {
    new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
    new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
    new BusinessClassPassenger { Name = "Janice" },
    new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
    new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        // C# 8 syntax
        /*
        FirstClassPassenger p when p.AirMiles > 35_000  => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000  => 1_750M,
        FirstClassPassenger _                           => 2_000M,
        BusinessClassPassenger _                        => 1_000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0   => 500M,
        CoachClassPassenger _                           => 650M,
        _                                               => 800M
        */

        // C# 9 or later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35_000  => 1_500M,
            > 15_000  => 1_750M,
            _         => 2_000M
        },
        /* 'OR'
            FirstClassPassenger { AirMiles: > 35000 } => 1500M,
            FirstClassPassenger { AirMiles: > 15000 } => 1750M,
            FirstClassPassenger                       => 2000M,
        */
        BusinessClassPassenger                         => 1_000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0  => 500M,
        CoachClassPassenger                            => 650M,
        _                                              => 800M
    };

    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

WriteLine();

WriteLine(":::::::::::::::: Working with record types :::::::::::::::: ");
WriteLine();

ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};
//jeff.FirstName = "Geoff"; - Error: error CS8852: Init-only property or indexer

WriteLine();

WriteLine(":::::::::::::::: Defining record types :::::::::::::::: ");
WriteLine();

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};

ImmutableVehicle repaintedCar = car
    with
{ Color = "Polymetal Grey Metallic" };

WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");

WriteLine();

WriteLine(":::::::::::::::: Equality of record types :::::::::::::::: ");
WriteLine();

AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };
WriteLine($"ac1 == ac2: { ac1 == ac2 }");
AnimalClass ar1 = new() { Name = "Rex" };
AnimalClass ar2 = new() { Name = "Rex" };
WriteLine($"ar1 == ar2: { ar1 == ar2 }");

WriteLine();

WriteLine(":::::::::::::::: Positional data members in records :::::::::::::::: ");
WriteLine();

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar;    // Calls the Deconstruct method.
WriteLine($"{who} is a {what}.");

WriteLine();

WriteLine(":::::::::::::::: Defining a primary constructor for a class :::::::::::::::: ");
WriteLine();

Headset vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}");

Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}.");
Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}.");
