using System;

class TypeCastingDemo
{
    static void Main()
    {
        // Implicit casting (smaller to larger type)
        int intValue = 10;
        double doubleValue = intValue;
        Console.WriteLine($"Implicit cast - int to double: {doubleValue}");

        // Explicit casting (larger to smaller type)
        double doubleNum = 9.78;
        int intNum = (int)doubleNum;
        Console.WriteLine($"Explicit cast - double to int: {intNum}");

        // String to int conversion
        string stringNum = "123";
        int convertedInt = int.Parse(stringNum);
        Console.WriteLine($"String to int: {convertedInt}");

        // Using TryParse for safe conversion
        if (int.TryParse("456", out int safeConvert))
        {
            Console.WriteLine($"Safe conversion - string to int: {safeConvert}");
        }

        // Convert class
        string stringFloat = "45.67";
        double convertedDouble = Convert.ToDouble(stringFloat);
        Console.WriteLine($"Using Convert - string to double: {convertedDouble}");

        // Boxing and unboxing
        int boxValue = 100;
        object boxedValue = boxValue; // Boxing
        int unboxValue = (int)boxedValue; // Unboxing
        Console.WriteLine($"Boxing and unboxing: {unboxValue}");
    }
}