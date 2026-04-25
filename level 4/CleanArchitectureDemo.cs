using System;

// ==============================================================================
// 1. DOMAIN LAYER (The core business rules. Zero external dependencies allowed.)
// ==============================================================================
namespace Domain
{
    public class Project 
    { 
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}

// ==============================================================================
// 2. APPLICATION LAYER (The use cases. Depends ONLY on the Domain layer.)
// ==============================================================================
namespace Application
{
    // Interface acting as a contract. The application doesn't care HOW data is saved.
    public interface IProjectRepository 
    { 
        void Save(Domain.Project project); 
    }

    public class CreateProjectUseCase
    {
        private readonly IProjectRepository _repo;
        public CreateProjectUseCase(IProjectRepository repo) => _repo = repo;
        
        public void Execute(string name) 
        {
            var newProject = new Domain.Project { Name = name };
            _repo.Save(newProject);
        }
    }
}

// ==============================================================================
// 3. INFRASTRUCTURE LAYER (External tools like Databases, APIs. Depends on Application.)
// ==============================================================================
namespace Infrastructure
{
    // This is where we write the actual SQL/Cloud database logic
    public class SqlProjectRepository : Application.IProjectRepository
    {
        public void Save(Domain.Project project) 
        {
            Console.WriteLine($"[Infrastructure] Saved '{project.Name}' to the SQL Database.");
        }
    }
}

// ==============================================================================
// 4. PRESENTATION LAYER (The UI or REST API. Depends on Application.)
// ==============================================================================
namespace WebApi
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Clean Architecture Demo ---\n");
            
            // In a real app, Dependency Injection does this automatically
            var repository = new Infrastructure.SqlProjectRepository();
            var useCase = new Application.CreateProjectUseCase(repository);

            Console.WriteLine("[API] Received HTTP POST request to create a project.");
            useCase.Execute("Site Alpha Foundation");
        }
    }
}