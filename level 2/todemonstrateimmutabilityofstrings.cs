using System;

class StringImmutabilityDemo
{
    static void Main()
    {
        Console.WriteLine("=== String Immutability Demonstration ===\n");

        // Example 1: Strings are immutable
        Console.WriteLine("Example 1: Immutability Basics");
        string str1 = "Hello";
        Console.WriteLine($"Original string: {str1}");
        Console.WriteLine($"String address: {str1.GetHashCode()}");

        string str2 = str1.ToUpper();
        Console.WriteLine($"After ToUpper(): {str2}");
        Console.WriteLine($"New string address: {str2.GetHashCode()}");
        Console.WriteLine($"Original string unchanged: {str1}\n");

        // Example 2: Concatenation creates new object
        Console.WriteLine("Example 2: Concatenation");
        string original = "World";
        Console.WriteLine($"Original: {original}, Address: {original.GetHashCode()}");
        
        original = original + " of C#";
        Console.WriteLine($"After concatenation: {original}, Address: {original.GetHashCode()}\n");

        // Example 3: Multiple references to same string
        Console.WriteLine("Example 3: Multiple References");
        string s1 = "CSharp";
        string s2 = s1;
        string s3 = "CSharp";
        
        Console.WriteLine($"s1: {s1}, Address: {s1.GetHashCode()}");
        Console.WriteLine($"s2: {s2}, Address: {s2.GetHashCode()}");
        Console.WriteLine($"s3: {s3}, Address: {s3.GetHashCode()}");
        Console.WriteLine($"s1 and s3 point to same object: {object.ReferenceEquals(s1, s3)}\n");

        // Example 4: String methods don't modify original
        Console.WriteLine("Example 4: Method Operations");
        string text = "Programming";
        Console.WriteLine($"Original: {text}");
        
        string replaced = text.Replace("m", "M");
        Console.WriteLine($"After Replace: {replaced}");
        Console.WriteLine($"Original unchanged: {text}\n");

        // Example 5: Why immutability matters
        Console.WriteLine("Example 5: Thread Safety");
        string threadSafeString = "ImmutableData";
        Console.WriteLine("Strings are thread-safe because they cannot be modified");
        Console.WriteLine($"String value: {threadSafeString}");
    }
}