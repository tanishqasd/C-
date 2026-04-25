using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

namespace AdvancedCSharp
{
    // 249. Role-Based vs Policy-Based Authorization
    // Roles ("Admin", "User") are rigid. Policies evaluate complex business rules.
    // E.g., "User must be a Site Manager AND have completed safety training within the last 365 days."

    public class SafetyTrainingRequirement : IAuthorizationRequirement { public int MaxDaysSinceTraining { get; } = 365; }

    // The handler evaluates the logic for the requirement
    public class SafetyTrainingHandler : AuthorizationHandler<SafetyTrainingRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SafetyTrainingRequirement requirement)
        {
            var trainingDateClaim = context.User.FindFirst("LastSafetyTrainingDate");
            if (trainingDateClaim != null && DateTime.TryParse(trainingDateClaim.Value, out DateTime trainingDate))
            {
                if ((DateTime.Now - trainingDate).TotalDays <= requirement.MaxDaysSinceTraining)
                {
                    context.Succeed(requirement); // Passed the check!
                }
            }
            return Task.CompletedTask;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register the custom handler
            builder.Services.AddSingleton<IAuthorizationHandler, SafetyTrainingHandler>();

            // Define the Policy
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeSafetyCompliant", policy =>
                    policy.Requirements.Add(new SafetyTrainingRequirement()));
            });

            var app = builder.Build();
            app.UseAuthorization();

            app.MapPost("/api/machinery/start", () => "Bulldozer Engine Started.")
               .RequireAuthorization("MustBeSafetyCompliant");

            Console.WriteLine("--- Policy-Based Authorization Active ---");
            // app.Run();
        }
    }
}