using System.Net.NetworkInformation; // To use Ping and so on.

partial class Program
{
    /// <summary>
    /// Pinging a server.
    /// </summary>
    static void PingInformation(Uri uri)
    {
        try
        {
            Ping ping = new();

            WriteLine("Ping Information:");
            WriteLine("Pinging server. Please wait...");
            PingReply reply = ping.Send(uri.Host);
            WriteLine($"{uri.Host} was pinged and replied: {reply.Status}.");

            if (reply.Status == IPStatus.Success)
            {
                WriteLine("Reply from {0} took {1:N0}ms", 
                    arg0: reply.Address,
                    arg1: reply.RoundtripTime);
            }
        }
        catch (Exception ex)
        {
            WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
        }

        WriteLine();
    }
}