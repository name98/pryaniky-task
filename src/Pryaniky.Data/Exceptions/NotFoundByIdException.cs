namespace Pryaniky.Data;

public abstract class NotFoundByIdException : Exception
{
    public NotFoundByIdException(string message) : base(message)
    {
    }
}
