# Bolek

## Solution

```powershell
dotnet new sln --format slnx --name Bolek
```

## Domain

```powershell
dotnet new classlib --framework net9.0 --output src/Domain --name Bolek.Domain
dotnet sln add src/Domain
```

## Application

```powershell
dotnet new classlib --framework net9.0 --output src/Application --name Bolek.Application
dotnet sln add src/Application
dotnet add src/Application reference src/Domain
dotnet add src/Application package AutoMapper
dotnet add src/Application package FluentValidation.DependencyInjectionExtensions
dotnet add src/Application package MediatR
dotnet add src/Application package Microsoft.Extensions.Logging.Abstractions
```

### AddApplication

```csharp
namespace Bolek.Application;

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(cfg =>
        {
        }, assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        services.AddValidatorsFromAssembly(assembly);
    }
}
```

## Infrastructure

```powershell
dotnet new classlib --framework net9.0 --output src/Infrastructure --name Bolek.Infrastructure
dotnet sln add src/Infrastructure
dotnet add src/Infrastructure reference src/Application
dotnet add src/Infrastructure package Microsoft.Extensions.Configuration.Binder
```

### AddInfrastructure

```csharp
namespace Bolek.Infrastructure;

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(cfg =>
        {
        }, assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        services.AddValidatorsFromAssembly(assembly);
    }
}
```

## WebApi + Observability

```powershell
dotnet new webapi --framework net9.0 --no-https --use-controllers --use-program-main --output src/WebApi --name Bolek.WebApi
dotnet sln add src/WebApi
dotnet add src/WebApi reference src/Infrastructure
dotnet add src/WebApi package OpenTelemetry.Exporter.OpenTelemetryProtocol
dotnet add src/WebApi package OpenTelemetry.Extensions.Hosting
dotnet add src/WebApi package OpenTelemetry.Instrumentation.AspNetCore
dotnet add src/WebApi package OpenTelemetry.Instrumentation.Http
```

## WebUI + Observability

```powershell
dotnet new mvc --framework net9.0 --no-https --use-program-main --output src/WebUI --name Bolek.WebUI
dotnet sln add src/WebUI
dotnet add src/WebUI reference src/Infrastructure
dotnet add src/WebUI package OpenTelemetry.Exporter.OpenTelemetryProtocol
dotnet add src/WebUI package OpenTelemetry.Extensions.Hosting
dotnet add src/WebUI package OpenTelemetry.Instrumentation.AspNetCore
dotnet add src/WebUI package OpenTelemetry.Instrumentation.Http
```

## CLI

```powershell
dotnet new console --framework net9.0 --use-program-main --output src/Cli --name Bolek.Cli
dotnet sln add src/Cli
dotnet add src/Cli reference src/Infrastructure
```

## Tests

### ArchitectureTests

```powershell
dotnet new mstest --framework net9.0 --output tests/ArchitectureTests --name Bolek.ArchitectureTests
dotnet sln add tests/ArchitectureTests
dotnet add tests/ArchitectureTests reference src/Domain
dotnet add tests/ArchitectureTests reference src/Application
dotnet add tests/ArchitectureTests reference src/Infrastructure
dotnet add tests/ArchitectureTests reference src/WebApi
dotnet add tests/ArchitectureTests package NetArchTest.Rules
dotnet add tests/ArchitectureTests package Shouldly
```
