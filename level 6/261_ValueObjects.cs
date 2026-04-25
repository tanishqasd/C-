using System;
using System.Collections.Generic;

namespace Level5_DDD
{
    // 261. Value Objects.
    // Unlike Entities, Value Objects have no ID. They are defined solely by their attributes. 
    // They are immutable; to change a value, you create a brand new object.
    
    public record GPSLocation(double Latitude, double Longitude); // Record types make this easy

    public class Dimensions : IEquatable<Dimensions>
    {
        public double Length { get; }
        public double Width { get; }

        public Dimensions(double length, double width)
        {
            if (length <= 0 || width <= 0) throw new ArgumentException("Dimensions must be positive.");
            Length = length;
            Width = width;
        }

        public bool Equals(Dimensions other) => 
            other != null && Length == other.Length && Width == other.Width;

        public override bool Equals(object obj) => Equals(obj as Dimensions);
        public override int GetHashCode() => HashCode.Combine(Length, Width);
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- DDD: Value Objects ---");
            var loc1 = new GPSLocation(19.076, 72.877);
            var loc2 = new GPSLocation(19.076, 72.877);

            Console.WriteLine($"Locations are identical by value: {loc1 == loc2}");
        }
    }
}