using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pryaniky.Domain.Abstractions;

namespace Pryaniky.Database.Configurations;

internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
    }
}