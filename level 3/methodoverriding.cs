using System;

namespace MethodOverridingDemo
{
    // 1. THE BASE CLASS
    class Animal
    {
        // The 'virtual' keyword explicitly grants permission for derived classes 
        // to override this method's behavior.
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a generic sound.");
        }
    }

    // 2. DERIVED CLASS A
    class Dog : Animal
    {
        // The 'override' keyword tells the compiler we are replacing 
        // the base class's implementation of MakeSound.
        public override void MakeSound()
        {
            Console.WriteLine("The dog barks: Woof! Woof!");
        }
    }

    // 3. DERIVED CLASS B
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The cat meows: Meow! Meow!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Method Overriding Demo ---\n");

            // Creating a standard base class object
            Animal genericAnimal = new Animal();
            
            // POLYMORPHISM IN ACTION: 
            // We can store a Dog and a Cat in variables of type 'Animal'.
            // Even though the variable type is 'Animal', the program knows 
            // to call the specific overridden method of the actual object type at runtime.
            Animal myDog = new Dog(); 
            Animal myCat = new Cat();

            Console.Write("Calling genericAnimal.MakeSound() -> ");
            genericAnimal.MakeSound();

            Console.Write("Calling myDog.MakeSound()       -> ");
            myDog.MakeSound();

            Console.Write("Calling myCat.MakeSound()       -> ");
            myCat.MakeSound();

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}