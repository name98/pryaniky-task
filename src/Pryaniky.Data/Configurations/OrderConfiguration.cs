using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pryaniky.Database.Configurations;
using Pryaniky.Domain;

internal class OrderConfiguration: EntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
    }
}