using System;

// Abstract class
abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    // Abstract method
    public abstract void MakeSound();

    // Concrete method
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping...");
    }
}

// Derived class implementing abstract class
class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof! Woof!");
    }
}

class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow! Meow!");
    }
}

// Interface
interface IVehicle
{
    void Start();
    void Stop();
}

class Car : IVehicle
{
    public void Start()
    {
        Console.WriteLine("Car engine started.");
    }

    public void Stop()
    {
        Console.WriteLine("Car engine stopped.");
    }
}

class Program
{
    static void Main()
    {
        // Using abstract class
        Animal dog = new Dog("Buddy");
        Animal cat = new Cat("Whiskers");

        dog.MakeSound();
        cat.MakeSound();
        dog.Sleep();

        Console.WriteLine();

        // Using interface
        IVehicle car = new Car();
        car.Start();
        car.Stop();
    }
}