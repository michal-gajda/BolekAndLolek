namespace Bolek.Domain.Exceptions;

public sealed class EmptyNameException : Exception
{
    public EmptyNameException(Exception? innerException = default) : base("Empty Name", innerException)
    {
    }
}
