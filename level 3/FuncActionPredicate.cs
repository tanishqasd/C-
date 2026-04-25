using System;

class Program
{
    static void Main()
    {
        // Func: Returns a value (Last type parameter is the return type)
        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine($"Func (Add): {add(10, 20)}");

        // Action: Does not return a value (void)
        Action<string> print = msg => Console.WriteLine($"Action: {msg}");
        print("Hello Action!");

        // Predicate: Always returns a boolean (used for checking conditions)
        Predicate<int> isEven = num => num % 2 == 0;
        Console.WriteLine($"Predicate (Is 4 even?): {isEven(4)}");
    }
}