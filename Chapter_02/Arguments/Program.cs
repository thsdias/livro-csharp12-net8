/*
    OperatingSystem Class in the System Namespace

    if (OperatingSystem.IsWindows())
    {
    // Execute code that only works on Windows.
    }
    else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
    {
    // Execute code that only works on Windows 10 or later.
    }
    else if (OperatingSystem.IsIOSVersionAtLeast(major: 14, minor: 5))
    {
    // Execute code that only works on iOS 14.5 or later.
    }
    else if (OperatingSystem.IsBrowser())
    {
    // Execute code that only works in the browser with Blazor.
    }

    OR

    // .NET Standard => NETSTANDARD2_0, NETSTANDARD2_1, and so on
    // Modern .NET => NET7_0, NET7_0_ANDROID, NET7_0_IOS, NET7_0_WINDOWS, and so on
    
    #if NET7_0_ANDROID
    // Compile statements that only work on Android.
    #elif NET7_0_IOS
    // Compile statements that only work on iOS.
    #else
    // Compile statements that work everywhere else.
    #endif
*/

if (args.Length < 3)
{
  WriteLine("You must specify two colors and cursor size, e.g.");
  WriteLine("dotnet run red yellow 50");
  return; // Stop running.
}

ForegroundColor = (ConsoleColor)Enum.Parse(
  enumType: typeof(ConsoleColor),
  value: args[0], ignoreCase: true);

BackgroundColor = (ConsoleColor)Enum.Parse(
  enumType: typeof(ConsoleColor),
  value: args[1], ignoreCase: true);

try
{
  CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
  WriteLine("The current platform does not support changing the size of the cursor.");
}

WriteLine($"There are {args.Length} arguments.");

foreach (var arg in args)
{
    WriteLine(arg);
}