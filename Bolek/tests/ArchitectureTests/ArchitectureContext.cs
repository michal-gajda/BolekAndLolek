namespace Bolek.ArchitectureTests;

using System.Reflection;

[TestClass]
public static class ArchitectureContext
{
    public const string DOMAIN_NAMESPACE = "Bolek.Domain";
    public const string APPLICATION_NAMESPACE = "Bolek.Application";
    public const string INFRASTRUCTURE_NAMESPACE = "Bolek.Infrastructure";
    public const string WEBAPI_NAMESPACE = "Bolek.WebApi";

    public static Assembly DomainAssembly { get; } = typeof(Bolek.Domain.AssemblyMarker).Assembly;
    public static Assembly ApplicationAssembly { get; } = typeof(Bolek.Application.AssemblyMarker).Assembly;
    public static Assembly InfrastructureAssembly { get; } = typeof(Bolek.Infrastructure.AssemblyMarker).Assembly;
    public static Assembly WebApiAssembly { get; } = typeof(Bolek.WebApi.AssemblyMarker).Assembly;
}
