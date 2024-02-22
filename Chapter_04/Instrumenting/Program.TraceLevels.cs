using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using static System.Console;

partial class Program
{
    // Nugget Packages:
    // dotnet add package Microsoft.Extensions.Configuration.Binder
    // dotnet add package Microsoft.Extensions.Configuration.Json

    // Create and Edit appsettings.json
    
    static void TraceLevels()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string settingsFile = "appsettings.json";
        string settingsPath = Path.Combine(currentDirectory, settingsFile);

        WriteLine($"Current Directory: {currentDirectory}");
        WriteLine("Processing: {0}", settingsPath);
        WriteLine("-- {0} contents --", settingsFile);
        WriteLine(File.ReadAllText(settingsPath));
        WriteLine("----");

        ConfigurationBuilder builder = new();
        builder.SetBasePath(currentDirectory);

        // Add the settings file to the processed configuration and make it
        // mandatory so an exception will be thrown if the file is not found.
        builder.AddJsonFile(settingsFile, optional: false, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        TraceSwitch ts = new(
            displayName: "PacktSwitch", 
            description: "This switch is set via a JSON config");

        configuration.GetSection("PacktSwitch").Bind(ts);

        WriteLine($"Trace switch value: {ts.Value}");
        WriteLine($"Trace switch level: {ts.Level}");

        Trace.WriteLine(ts.TraceError, "Trace error");
        Trace.WriteLine(ts.TraceWarning, "Trace warning");
        Trace.WriteLine(ts.TraceInfo, "Trace information");
        Trace.WriteLine(ts.TraceVerbose, "Trace verbose");

        // Close the text file (also flushes) and release resources.
        Debug.Close();
        Trace.Close();
        
        WriteLine("Press enter to exit.");
        ReadLine();
    }
}