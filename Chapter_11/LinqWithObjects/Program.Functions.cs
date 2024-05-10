
partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");

        // Question: Which names end with an M?
        // (using a LINQ extension method)
        var query1 = names.Where(name => name.EndsWith("m"));

        // Question: Which names end with an M?
        // (using LINQ query comprehension syntax)
        var query2 = from name in names where name.EndsWith("m") select name;

        // Answer returned as an array of strings containing Pam and Jim.
        string[] result1 = query1.ToArray();

        // Answer returned as a list of strings containing Pam and Jim.
        List<string> result2 = query2.ToList();

        // Answer returned as we enumerate over the results.
        foreach(string name in query1)
        {
            WriteLine(name); // outputs Pam
            names[2] = "Jimmy"; // Change Jim to Jimmy.
                // On the second iteration Jimmy does not end with an "m" so it does not get output.
        }

        WriteLine();
    }

    private static void FilteringUsingWhere(string[] names)
    {
        SectionTitle("Filtering entities using Where");

        // Explicitly creating the required delegate.
        //var query = names.Where(new Func<string, bool>(NameLongerThanFour));

        // The compiler creates the delegate automatically.
        //var query = names.Where(NameLongerThanFour);

        // Using a lambda expression instead of a named method.
        var query = names
            .Where(name => name.Length > 4)
            .OrderBy(name => name.Length)
            .ThenBy(name => name);

        foreach (var item in query)
        {
            WriteLine(item);
        }

        WriteLine();
    }

    static void FilteringByType()
    {
        SectionTitle("Filtering by type");

        List<Exception> exceptions = new()
        {
            new ArgumentException(), 
            new SystemException(),
            new IndexOutOfRangeException(), 
            new InvalidOperationException(),
            new NullReferenceException(), 
            new InvalidCastException(),
            new OverflowException(), 
            new DivideByZeroException(),
            new ApplicationException()
        };

        IEnumerable<ArithmeticException> arithmeticExceptions = exceptions.OfType<ArithmeticException>();

        foreach (ArithmeticException exception in arithmeticExceptions)
        {
            WriteLine(exception);
        }

        WriteLine();
    }   

    static void Output(IEnumerable<string> cohort, string description = "")
    {
        if (!string.IsNullOrEmpty(description))
            WriteLine(description);

        Write(" ");
        WriteLine(String.Join(", ", cohort.ToArray()));
        WriteLine();
    }

    static void WorkingWithSets()
    {
        string[] cohort1 = { "Rachel", "Gareth", "Jonathan", "George" };
        string[] cohort2 = { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
        string[] cohort3 = { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

        SectionTitle("The cohorts");
        Output(cohort1, "Cohort 1");
        Output(cohort2, "Cohort 2");
        Output(cohort3, "Cohort 3");

        SectionTitle("Set operations");
        Output(cohort2.Distinct(), "cohort2.Distinct()");
        /*
            For the DistinctBy example, instead of removing duplicates by comparing the whole name, 
            we define a lambda key selector to remove duplicates by comparing the first two characters, 
            so Jared is removed because Jack already is a name that starts with Ja.
        */
        Output(cohort2.DistinctBy(name => name.Substring(0, 2)), "cohort2.DistinctBy(name => name.Substring(0, 2):");
        Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
        Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3)");
        Output(cohort2.Intersect(cohort3), "cohort2.Intersect(cohort3)");
        Output(cohort2.Except(cohort3), "cohort2.Except(cohort3)");
        Output(cohort1.Zip(cohort2, (c1, c2) => $"{c1} matched with {c2}"), "cohort1.Zip(cohort2)");
    }

    /// <summary>
    /// Returns true for a name longer than four characters.
    /// </summary>
    static bool NameLongerThanFour(string name)
    {
        return name.Length > 4;
    }
}