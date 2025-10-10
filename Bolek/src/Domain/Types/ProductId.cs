namespace Bolek.Domain.Types;

public readonly record struct ProductId
{
    public Guid Value { get; private init; }

    public ProductId(Guid value)
    {
        this.Value = value;
    }
}
