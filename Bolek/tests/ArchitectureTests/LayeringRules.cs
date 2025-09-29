namespace Bolek.ArchitectureTests;

[TestClass]
public sealed class LayeringRules
{
    [TestMethod]
    public void Domain_Should_Not_Depend_On_Application_Infrastructure_Web()
    {
        var result = Types
            .InAssembly(ArchitectureContext.DomainAssembly)
            .Should()
            .NotHaveDependencyOnAny(ArchitectureContext.INFRASTRUCTURE_NAMESPACE, ArchitectureContext.WEBAPI_NAMESPACE)
            .GetResult();

        var failingTypeNames = (result.FailingTypes ?? Enumerable.Empty<Type>())
            .Select(typeInfo => typeInfo.FullName)
            .ToArray();

        result.IsSuccessful.ShouldBeTrue($"Failing types: {string.Join(", ", failingTypeNames)}");
    }

    [TestMethod]
    public void Application_Should_Not_Depend_On_Infrastructure_Or_Web()
    {
        var result = Types
            .InAssembly(ArchitectureContext.ApplicationAssembly)
            .Should()
            .NotHaveDependencyOnAny(ArchitectureContext.INFRASTRUCTURE_NAMESPACE, ArchitectureContext.WEBAPI_NAMESPACE)
            .GetResult();

        var failingTypeNames = (result.FailingTypes ?? Enumerable.Empty<Type>())
            .Select(typeInfo => typeInfo.FullName)
            .ToArray();

        result.IsSuccessful.ShouldBeTrue($"Failing types: {string.Join(", ", failingTypeNames)}");
    }

    [TestMethod]
    public void Infrastructure_Should_Not_Depend_On_Web()
    {
        var result = Types
            .InAssembly(ArchitectureContext.InfrastructureAssembly)
            .Should()
            .NotHaveDependencyOn(ArchitectureContext.WEBAPI_NAMESPACE)
            .GetResult();

        var failingTypeNames = (result.FailingTypes ?? Enumerable.Empty<Type>())
            .Select(typeInfo => typeInfo.FullName)
            .ToArray();

        result.IsSuccessful.ShouldBeTrue($"Failing types: {string.Join(", ", failingTypeNames)}");
    }
}
