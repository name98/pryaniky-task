using Pryaniky.Domain.Abstractions;

namespace Pryaniky.Domain;

public class Order : Entity
{
    public List<Product> Products { get; set; } = [];
}

