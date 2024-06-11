using Pryaniky.Domain.Abstractions;

namespace Pryaniky.Data;

public class DbEntityNotFoundByIdException<T> : NotFoundByIdException
    where T : IEntity
{
    public DbEntityNotFoundByIdException(Guid id) : base($"Not found. Entity type: {typeof(T).Name}. Id: {id}.")
    {
    }
}
