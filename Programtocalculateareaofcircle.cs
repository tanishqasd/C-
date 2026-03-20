using System;

class CircleAreaCalculator
{
    static void Main()
    {
        Console.Write("Enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());
        
        double area = Math.PI * radius * radius;
        
        Console.WriteLine($"Area of the circle: {area:F2}");
    }
}