using System.Net; // To use IPHostEntry, Dns, IPAddress.

partial class Program
{
    /// <summary>
    /// Working with URIs, DNS, and IP addresses.
    /// </summary>
    static void NetworkInformation(Uri uri)
    {
        WriteLine("\nNetwork Information:");
        WriteLine($"Scheme: {uri.Scheme}"); 
        WriteLine($"Port: {uri.Port}"); 
        WriteLine($"Host: {uri.Host}"); 
        WriteLine($"Path: {uri.AbsolutePath}"); 
        WriteLine($"Query: {uri.Query}");

        IPHostEntry entry = Dns.GetHostEntry(uri.Host); 

        WriteLine($"\n{entry.HostName} has the following IP addresses:"); 

        foreach (IPAddress address in entry.AddressList)
        {
            WriteLine($"  {address} ({address.AddressFamily})");
        }

        WriteLine();
    }
}
