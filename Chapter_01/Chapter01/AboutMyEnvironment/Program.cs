namespace AboutMyEnvironment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"CurrentDirectory: {Environment.CurrentDirectory}");
            Console.WriteLine($"OSVersion: {Environment.OSVersion.VersionString}");
            Console.WriteLine("Namespace: {0}", typeof(Program).Namespace);
        }
    }
}
