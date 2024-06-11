using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pryaniky.Database.Configurations;
using Pryaniky.Domain;

internal class ProductConfiguration: EntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.HasIndex(p => p.Title);

        builder.HasMany(p => p.Orders)
           .WithMany(o => o.Products);
    }
}
