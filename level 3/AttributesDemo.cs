using System;

class Program
{
    static void Main()
    {
        OldMethod(); // This will trigger a compiler warning
    }

    // Applying a built-in attribute to mark this method as deprecated
    [Obsolete("Use NewMethod() instead.")]
    static void OldMethod()
    {
        Console.WriteLine("This is the old method.");
    }

    static void NewMethod()
    {
        Console.WriteLine("This is the new method.");
    }
}