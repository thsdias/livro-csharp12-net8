﻿
WriteLine("I can run everywhere!");
WriteLine($"OS Version is {Environment.OSVersion}.");

if (OperatingSystem.IsMacOS())
    WriteLine("I am macOS.");
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10, build: 22000))
    WriteLine("I am Windows 11.");
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
    WriteLine("I am Windows 10.");
else
    WriteLine("I am some outher mysterious OS.");

WriteLine("Press any key to stop me.");

ReadKey(intercept: true); // Do not output the key that was pressed.