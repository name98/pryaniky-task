using Pryaniky.Domain.Abstractions;

namespace Pryaniky.Domain;

public class Product : Entity
{
    public required string Title { get; set; }

    public List<Order> Orders { get; set; } = [];
}

