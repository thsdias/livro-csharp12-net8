
Write("Enter a valid web address (or press Enter): "); 
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url))
    url = "https://stackoverflow.com/search?q=securestring";

Uri uri = new(url);
WriteLine($"\nURL: {url}"); 

// Common types for working with network resources.
NetworkInformation(uri);

// Ping a web server to check its health.
PingInformation(uri);
