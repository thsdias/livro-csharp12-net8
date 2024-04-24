using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>

namespace Packt.Shared;

public class Academy : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Course>? Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Academy.db");

        string connection = $"Filename={path}";
        //string connection = @"Data Source=.;Initial Catalog=Academy;Integrated Security=true;MultipleActiveResultSets=true;";

        WriteLine($"Connection: {connection}");

        optionsBuilder.UseSqlite(connection);
        //optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API validation rules.
        modelBuilder.Entity<Student>()
            .Property(s => s.LastName).HasMaxLength(30).IsRequired();

        // Populate database with sample data.
        Student alice = new() { StudentId = 1, FirstName = "Alice", LastName = "Jones" };
        Student bob = new() { StudentId = 2, FirstName = "Bob", LastName = "Smith" };
        Student cecilia = new() { StudentId = 3, FirstName = "Cecilia", LastName = "Ramirez" };
        
        modelBuilder.Entity<Student>().HasData(alice, bob, cecilia);

        Course csharp = new() { CourseId = 1, Title = "C# 11 and .NET 7"};
        Course webdev = new() { CourseId = 2, Title = "Web Development" };
        Course python = new() { CourseId = 3, Title = "Python for Beginners" };

        modelBuilder.Entity<Course>().HasData(csharp, webdev, python);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity(e => e.HasData(
                // All students signed up for C# course.
                new { CoursesCourseId = 1, StudentsStudentId = 1 },
                new { CoursesCourseId = 1, StudentsStudentId = 2 },
                new { CoursesCourseId = 1, StudentsStudentId = 3 },
                // Only Bob signed up for Web Dev.
                new { CoursesCourseId = 2, StudentsStudentId = 2 },
                // Only Cecilia signed up for Python.
                new { CoursesCourseId = 3, StudentsStudentId = 3 }
            ));
    }
}