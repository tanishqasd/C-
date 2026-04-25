using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

// 1. Initialize the Web Application
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Dummy data for our API
var users = new List<string> { "Tanishqa", "Alice", "Bob" };

// 2. Define the REST Endpoints (Routes)
app.MapGet("/", () => "Welcome to the Basic REST API!");

// GET: Retrieve all users
app.MapGet("/api/users", () => users);

// GET: Retrieve a specific user by ID (index)
app.MapGet("/api/users/{id}", (int id) => 
{
    if (id < 0 || id >= users.Count) return Results.NotFound("User not found.");
    return Results.Ok(users[id]);
});

// POST: Add a new user
app.MapPost("/api/users", (string name) => 
{
    users.Add(name);
    return Results.Created($"/api/users/{users.Count - 1}", name);
});

// 3. Run the Server
app.Run();