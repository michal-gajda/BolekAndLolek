namespace Bolek.Domain.UnitTests.Entities;

using Bolek.Domain.Entities;

public sealed class ProductEntityTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateDefaultProduct()
    {
        // Arrange
        var id = new ProductId(Guid.NewGuid());
        var name = "Name";

        // Act
        var entity = new ProductEntity(id, name);

        // Assert
        entity.Id.ShouldBe(id);
        entity.Name.ShouldBe(name);
    }

    [Test]
    public void CreateDefaultProductWithTrimmedName()
    {
        // Arrange
        var id = new ProductId(Guid.NewGuid());
        var name = " Name ";
        var trimmedName = "Name";

        // Act
        var entity = new ProductEntity(id, name);

        // Assert
        entity.Id.ShouldBe(id);
        entity.Name.ShouldBe(trimmedName);
    }
}
