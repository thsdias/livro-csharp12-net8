
#region Exploring unary operators

int a = 3; 
int b = a++;
WriteLine($"a is {a}, b is {b}");

int c = 3;
int d = ++c; // Prefix means increment c before assigning it.
WriteLine($"c is {c}, d is {d}");

#endregion

#region Exploring binary arithmetic operators

int e = 11; 
int f = 3;
WriteLine($"e is {e}, f is {f}"); 
WriteLine($"e + f = {e + f}"); 
WriteLine($"e - f = {e - f}"); 
WriteLine($"e * f = {e * f}"); 
WriteLine($"e / f = {e / f}"); 
WriteLine($"e % f = {e % f}");

double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}"); 
WriteLine($"g / f = {g / f}");

#endregion

#region Assignment operators

int z = 6;
z += 3; // Equivalent to: z = z + 3;
z -= 3; // Equivalent to: z = z - 3;
z *= 3; // Equivalent to: z = z * 3;
z /= 3; // Equivalent to: z = z / 3;

#endregion

#region Null-coalescing operators

string? authorName = ReadLine(); // Prompt user to enter an author name.

// The maxLength variable will be the length of authorName if it is not null, or 30 if authorName is null.
int maxLength = authorName?.Length ?? 30;

// The authorName variable will be "unknown" if authorName was null.
authorName ??= "unknown";

#endregion

#region Exploring logical operators

bool p = true;
bool q = false;

WriteLine($"AND  | p     | q    ");
WriteLine($"p    | {p & p,-5} | {p & q,-5} ");
WriteLine($"q    | {q & p,-5} | {q & q,-5} ");
WriteLine();
WriteLine($"OR   | p     | q    ");
WriteLine($"p    | {p | p,-5} | {p | q,-5} ");
WriteLine($"q    | {q | p,-5} | {q | q,-5} ");
WriteLine();
WriteLine($"XOR  | p     | q    ");
WriteLine($"p    | {p ^ p,-5} | {p ^ q,-5} ");
WriteLine($"q    | {q ^ p,-5} | {q ^ q,-5} ");

#endregion

#region Exploring conditional logical operators

static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
}

WriteLine();

// Note that DoStuff() returns true.
WriteLine($"p & DoStuff() = {p & DoStuff()}"); 
WriteLine($"q & DoStuff() = {q & DoStuff()}");

WriteLine();
WriteLine($"p && DoStuff() = {p && DoStuff()}"); 
WriteLine($"q && DoStuff() = {q && DoStuff()}");

#endregion

#region Exploring bitwise and binary shift operators

WriteLine();

int x = 10;
int y = 6;

WriteLine($"Expression | Decimal |   Binary");
WriteLine($"-------------------------------");
WriteLine($"x          | {x,7} | {x:B8}");
WriteLine($"y          | {y,7} | {y:B8}");
WriteLine($"x & y      | {x & y,7} | {x & y:B8}");
WriteLine($"x | y      | {x | y,7} | {x | y:B8}");
WriteLine($"x ^ y      | {x ^ y,7} | {x ^ y:B8}");

// Left-shift x by three bit columns.
WriteLine($"x << 3     | {x << 3,7} | {x << 3:B8}");

// Multiply x by 8.
WriteLine($"x * 8      | {x * 8,7} | {x * 8:B8}");

// Right-shift y by one bit column.
WriteLine($"y >> 1     | {y >> 1,7} | {y >> 1:B8}");

#endregion

#region Miscellaneous operators

int age = 50;
WriteLine($"The {nameof(age)} variable uses {sizeof(int)} bytes of memory.");

// How many operators in the following statement?
char firstDigit = age.ToString()[0];

// There are four operators:
// = is the assignment operator
// . is the member access operator
// () is the invocation operator
// [] is the indexer access operator

#endregion