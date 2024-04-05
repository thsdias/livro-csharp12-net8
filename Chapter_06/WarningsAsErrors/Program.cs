
Console.Write("Enter a name: ");
string? name = Console.ReadLine();

if (name is null) return;
Console.WriteLine($"Hello, {name} has {name.Length} characters!");
