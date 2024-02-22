using CallStackExceptionHandlingLib;
using static System.Console;

WriteLine("In Main");
Alpha();

void Alpha()
{
    WriteLine("In Aplpha");
    Beta();
}

void Beta()
{
    try
    {
        WriteLine("In Beta");
        Processor.Gamma();
    }
    /*
        // Throw the caught exception as if it happened here this will lose the original call stack.
        throw e;

        // Rethrow the caught exeption and retain its original call statck.
        throw;

        // Throw a new exception with the caught exception nested within it.
        throw new InvalidOperationException(message: "Calculation had invalid values. See inner exception for why.",
            innerException: e);
    */
    catch (Exception)
    {
        //WriteLine($"Caught this: {ex.Message}");
        //throw ex;
        
        throw;
    }
}