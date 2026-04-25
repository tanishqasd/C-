using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

// IdentityServer is a framework for building your own centralized login/auth server 
// (Single Sign-On), separating user management from your main application logic.
var builder = WebApplication.CreateBuilder(args);

// Define what API resources we are protecting
var apiScopes = new List<ApiScope> { new ApiScope("constructionApi", "Construction Management API") };

// Define the client applications allowed to connect
var clients = new List<Client>
{
    new Client
    {
        ClientId = "mobile-app",
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        ClientSecrets = { new Secret("super-secret-key".Sha256()) },
        AllowedScopes = { "constructionApi" }
    }
};

// Register IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryApiScopes(apiScopes)
    .AddInMemoryClients(clients);

var app = builder.Build();

// Enable the IdentityServer middleware
app.UseIdentityServer();

app.MapGet("/", () => "Identity Server is running. Request tokens here.");

app.Run();