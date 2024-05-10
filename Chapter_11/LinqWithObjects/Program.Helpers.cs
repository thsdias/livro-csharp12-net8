
partial class Program
{
    private static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine();
        WriteLine($"*** {title} ***");
        WriteLine();
        ForegroundColor = previousColor;
    }
}