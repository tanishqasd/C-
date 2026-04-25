# A Dockerfile is a blueprint to package your application into a standardized "container"
# so it runs exactly the same way on any computer or cloud server.

# 1. Build Stage
# Use the heavy SDK image to compile the code
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies (NuGet packages)
COPY ["ConstructionApp.csproj", "./"]
RUN dotnet restore "ConstructionApp.csproj"

# Copy the rest of the code and publish an optimized release build
COPY . .
RUN dotnet publish "ConstructionApp.csproj" -c Release -o /app/publish

# 2. Runtime Stage
# Use a much smaller, lightweight runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy only the compiled output from the Build Stage
COPY --from=build /app/publish .

# Expose port 80 for web traffic
EXPOSE 80

# Command to start the application
ENTRYPOINT ["dotnet", "ConstructionApp.dll"]