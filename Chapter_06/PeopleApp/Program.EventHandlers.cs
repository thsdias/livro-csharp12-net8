using Packt.Shared;

// No namespace declaration so this extends the Program class in the null namespace.
partial class Program
{
    /// <summary>
    /// A method to handle the Shout event received by the harry object.
    /// </summary>
    private static void Harry_Shout(object? sender, EventArgs e)
    {
        if (sender is null)
            return; // If no sender, then do nothing.

        if (sender is not Person p)
            return; // If sender is not a Person, then do nothing.

        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }

    /// <summary>
    /// Another method to handle the event received by the harry object.
    /// </summary>
    private static void Harry_Shout_2(object? sender, EventArgs e)
    {
        WriteLine("Stop it!");
    }
}