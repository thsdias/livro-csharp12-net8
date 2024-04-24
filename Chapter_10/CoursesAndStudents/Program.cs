using Microsoft.EntityFrameworkCore; // for GenerateCreateScript()
using Packt.Shared; // Academy

// Info:
// https://github.com/markjprice/cs12dotnet8/blob/main/docs/ch10-code-first.md
// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

// About the TPH, TPT, and TPC mapping strategies:
// https://learn.microsoft.com/en-us/ef/core/modeling/inheritance

using (Academy a = new())
{
    bool deleted = await a.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await a.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL script used to create database:");
    WriteLine(a.Database.GenerateCreateScript());

    foreach (Student s in a.Students.Include(s => s.Courses))
    {
        WriteLine("{0} {1} attends the following {2} courses:",
        s.FirstName, s.LastName, s.Courses.Count);

        foreach (Course c in s.Courses)
        {
            WriteLine($"  {c.Title}");
        }

        WriteLine();
    }
    
    WriteLine();
}
