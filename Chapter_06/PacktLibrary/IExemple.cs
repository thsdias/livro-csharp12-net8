/*

// These are both "classic" interfaces in that they are pure contracts.
// They have no functionality, just the signatures of members that 
// must be implemented.
interface IAlpha 
{ 
    // A method that must be implemented in any type that implements 
    // this interface.
    void M1();
}

interface IBeta 
{
    void M2(); // Another method.
} 

// A type (a struct in this case) implementing an interface.
// ": IAlpha" means Gamma promises to implement all members of IAlpha.
struct Gamma : IAlpha
{
    void M1() 
    { 
        // implementation  
    }
}

// A type (a class in this case) implementing two interfaces.
class Delta : IAlpha, IBeta 
{
    void M1() 
    { 
        // implementation  
    }

    void M2() 
    { 
        // implementation  
    }
}

// A sub class inheriting from a base aka super class.
// ": Delta" means inherit all members from Delta.
class Episilon : Delta
{
    // This can be empty because this inherits M1 and M2 from Delta.
    // You could also add new members here.
}

// A class with one inheritable method and one abstract method 
// that must be implemented in sub classes. A class with at least 
// one abstract member must be decorated with the abstract keyword 
// to prevent instantiation.
abstract class Zeta
{
    // An implemented method would be inherited.
    void M3() 
    { 
        // implementation  
    }

    // A method that must be implemented in any type that inherits 
    // this abstract class.
    abstract void M4();
}

// A class inheriting the M3 method from Zeta but it must provide 
// an implementation for M4.
class Eta : Zeta 
{
    void M4() 
    { 
        // implementation  
    } 
}

// In C# 8 and later, interfaces can have default implementations 
// as well as members that must be implemented.
// Requires: .NET Standard 2.1, .NET Core 3.0 or later.
interface ITheta 
{
    void M3() 
    { 
        // implementation  
    }

    void M4();
}

// A class inheriting the default implementation from an interface 
// and must provide an implementation for M4.
class Iota : ITheta 
{
    void M4() 
    { 
        // implementation  
    }
}

*/
