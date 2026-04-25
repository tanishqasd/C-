using System;

namespace DestructorDemo
{
    class ResourceHandler
    {
        // 1. Constructor: Called when the object is instantiated
        public ResourceHandler()
        {
            Console.WriteLine("Constructor called: Object is created and resources are allocated.");
        }

        // 2. Destructor (Finalizer): Called by the Garbage Collector
        ~ResourceHandler()
        {
            Console.WriteLine("Destructor called: Object is being destroyed and resources freed.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Program Started ---");

            // We call a separate method to create the object so that it 
            // goes out of scope as soon as the method finishes.
            CreateAndDestroyObject();

            // Force the Garbage Collector to run.
            // Note: We only do this here for demonstration purposes so you can 
            // actually see the destructor print to the console before the program ends.
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("--- Program Ended ---");
        }

        static void CreateAndDestroyObject()
        {
            // Instantiating the object
            ResourceHandler myObject = new ResourceHandler();
            
            // As soon as this method ends, 'myObject' goes out of scope 
            // and becomes eligible for garbage collection.
        }
    }
}