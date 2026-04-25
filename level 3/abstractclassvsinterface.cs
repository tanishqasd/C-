using System;

// Abstract Class - can have implementation, state, and access modifiers
abstract class Animal
{
    // Abstract property
    public abstract string Name { get; }
    
    // Abstract method
    public abstract void MakeSound();
    
    // Concrete method with implementation
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping...");
    }
    
    // Virtual method
    public virtual void Eat()
    {
        Console.WriteLine($"{Name} is eating...");
    }
}

// Interface - only method signatures, no implementation (before C# 8.0)
interface IMovable
{
    void Move();
    void Run();
}

// Interface - can have properties
interface ISwimmable
{
    bool CanSwim { get; }
}

// Concrete class inheriting abstract class and implementing interfaces
class Dog : Animal, IMovable, ISwimmable
{
    public override string Name => "Dog";
    public bool CanSwim => true;
    
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
    
    public void Move()
    {
        Console.WriteLine("Dog is moving on land");
    }
    
    public void Run()
    {
        Console.WriteLine("Dog is running fast!");
    }
}

class Fish : Animal, IMovable, ISwimmable
{
    public override string Name => "Fish";
    public bool CanSwim => true;
    
    public override void MakeSound()
    {
        Console.WriteLine("Fish makes bubbles...");
    }
    
    public void Move()
    {
        Console.WriteLine("Fish is swimming");
    }
    
    public void Run()
    {
        Console.WriteLine("Fish cannot run on land");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Abstract Class vs Interface ===\n");
        
        // Using abstract class reference
        Animal dog = new Dog();
        dog.MakeSound();      // Abstract method
        dog.Sleep();          // Concrete method from abstract class
        dog.Eat();            // Virtual method
        
        Console.WriteLine();
        
        Animal fish = new Fish();
        fish.MakeSound();
        fish.Sleep();
        fish.Eat();
        
        Console.WriteLine("\n=== Interface Implementation ===\n");
        
        // Using interface references
        IMovable movableDog = new Dog();
        movableDog.Move();
        movableDog.Run();
        
        Console.WriteLine();
        
        ISwimmable swimmableFish = new Fish();
        Console.WriteLine($"Fish can swim: {swimmableFish.CanSwim}");
        
        Console.WriteLine("\n=== Key Differences ===");
        Console.WriteLine("Abstract Class:");
        Console.WriteLine("- Can have state (fields)");
        Console.WriteLine("- Can have constructors");
        Console.WriteLine("- Can have access modifiers (public, private, protected)");
        Console.WriteLine("- Single inheritance only");
        
        Console.WriteLine("\nInterface:");
        Console.WriteLine("- Only contracts (method signatures)");
        Console.WriteLine("- No state (fields)");
        Console.WriteLine("- All members are public");
        Console.WriteLine("- Multiple inheritance supported");
    }
}