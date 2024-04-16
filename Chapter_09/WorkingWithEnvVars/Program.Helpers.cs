
// null namespace to merge with auto-generated Program.
partial class Program
{
    private static void SectionTitle(string title)
    {
        WriteLine();
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"*** {title} ***");
        ForegroundColor = previousColor;
        WriteLine();
    }

    private static void DictionaryToTable(IDictionary dictionary)
    {
        Table table = new();
        table.AddColumn("Key");
        table.AddColumn("Value");

        foreach (string key in dictionary.Keys)
        {
            table.AddRow(key, dictionary[key]!.ToString()!);
        }

        AnsiConsole.Write(table);
    }
}