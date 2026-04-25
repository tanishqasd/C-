using System;

// Constraint: T must be a class (reference type), not a struct/primitive
class ReferenceRepository<T> where T : class
{
    public void Save(T entity)
    {
        Console.WriteLine($"Saved {entity.GetType().Name} to database.");
    }
}

class Employee { }

class Program
{
    static void Main()
    {
        ReferenceRepository<Employee> repo = new ReferenceRepository<Employee>();
        repo.Save(new Employee());

        // ReferenceRepository<int> badRepo = new ReferenceRepository<int>(); // This would not compile
    }
}