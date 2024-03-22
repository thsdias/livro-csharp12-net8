using Env = System.Environment;

public class EnvironmentTest
{
    public EnvironmentTest()
    {
        WriteLine(Env.OSVersion);
        WriteLine(Env.MachineName);
        WriteLine(Env.CurrentDirectory);
        WriteLine(Env.WorkingSet);
        WriteLine(Env.Version);
        WriteLine(Env.UserName);
    }
}