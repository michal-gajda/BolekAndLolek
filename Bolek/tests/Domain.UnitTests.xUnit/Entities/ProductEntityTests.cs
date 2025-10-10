namespace Bolek.Domain.UnitTests;

using Bolek.Domain.Entities;

public sealed class ProductEntityTests
{
    [Fact]
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

    [Fact]
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
