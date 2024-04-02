using Packt.Shared;

Util.PrintTitle("Working with null values");

int thisCannotBeNull = 4;
//thisCannotBeNull = null; CS0037 compiler error!
WriteLine(thisCannotBeNull);

int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

// The actual type of int? is Nullable<int>.
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

Util.PrintTitle("Declaring non-nullable variables and parameters");

Address address = new(city: "London")
{
    Building = null,
    Street = null!, // null-forgiving operator.
    Region = "UK"
};

WriteLine(address.Building?.Length);

if (address.Street is not null)
  WriteLine(address.Street.Length);

Util.PrintTitle("Checking for null");

string authorName = null;
int? authorNameLength;

// The following throws a NullReferenceException.
//authorNameLength = authorName.Length;

// Instead of throwing an exception, null is assigned.
authorNameLength = authorName?.Length;

// Result will be 25 if authorName?.Length is null.
authorNameLength = authorName?.Length ?? 25;

Util.PrintTitle("Checking for null in method parameters");

// In earlier versions of C#.
/*
static void Hire(Person manager, Person employee)
{
    if (manager is null)
        throw new ArgumentNullException(paramName: nameof(manager));

    if (employee is null)
        throw new ArgumentNullException(paramName: nameof(employee));
}
*/

// In C# 10.
/*
public void Hire(Person manager, Person employee)
{
    ArgumentNullException.ThrowIfNull(manager);
    ArgumentNullException.ThrowIfNull(employee);
    ...
}
*/

// C# 11 previews.
// Unfortunately, the Microsoft Team eventually decided to remove the feature.
/*
public void Hire(Person manager!!, Person employee!!)
{
  ...
}
*/

WriteLine();
