using System;

// CQRS (Command Query Responsibility Segregation) is a pattern that strictly 
// separates read operations (Queries) from write operations (Commands).

// ==========================================================
// 1. COMMANDS (Writes: Change state, return little to no data)
// ==========================================================
public class CreateWorkerCommand 
{ 
    public string Name { get; set; } 
    public string Role { get; set; }
}

public class CreateWorkerCommandHandler
{
    public void Handle(CreateWorkerCommand command)
    {
        // Logic to write to the primary transactional database
        Console.WriteLine($"[Command] Writing new worker '{command.Name}' ({command.Role}) to the Master Database.");
    }
}

// ==========================================================
// 2. QUERIES (Reads: Never change state, return formatted data)
// ==========================================================
public class GetWorkerQuery 
{ 
    public int WorkerId { get; set; } 
}

public class WorkerDto 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
}

public class GetWorkerQueryHandler
{
    public WorkerDto Handle(GetWorkerQuery query)
    {
        // Logic to read from a separate, heavily-optimized read database (like Redis or ElasticSearch)
        Console.WriteLine($"[Query] Fetching worker #{query.WorkerId} from the Read-Replica Cache.");
        return new WorkerDto { Id = query.WorkerId, Name = "Tanishqa" };
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- CQRS Pattern Demo ---\n");

        // Executing a Write
        var commandHandler = new CreateWorkerCommandHandler();
        commandHandler.Handle(new CreateWorkerCommand { Name = "Alice", Role = "Foreman" });

        Console.WriteLine();

        // Executing a Read
        var queryHandler = new GetWorkerQueryHandler();
        var worker = queryHandler.Handle(new GetWorkerQuery { WorkerId = 101 });
        Console.WriteLine($"Result: {worker.Name} retrieved successfully.");
    }
}