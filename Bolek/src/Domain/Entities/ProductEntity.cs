using Bolek.Domain.Exceptions;

namespace Bolek.Domain.Entities;

public sealed class ProductEntity
{
    public ProductId Id { get; private init; }
    public string Name { get; private set; } = string.Empty;

    public ProductEntity(ProductId id, string name)
    {
        this.Id = id;
        this.SetName(name);
    }

    public void SetName(string name)
    {
        var trimmedName = name.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new EmptyNameException();
        }

        this.Name = trimmedName;
    }
}
