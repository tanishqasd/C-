using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        long a = Convert.ToInt64(Console.ReadLine());

        Console.Write("Enter second number: ");
        long b = Convert.ToInt64(Console.ReadLine());

        long gcd = GCD(a, b);
        long lcm = LCM(a, b, gcd);

        Console.WriteLine($"GCD of {a} and {b} is: {gcd}");
        Console.WriteLine($"LCM of {a} and {b} is: {lcm}");
    }

    static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static long LCM(long a, long b, long gcd)
    {
        return (a / gcd) * b;
    }
}
