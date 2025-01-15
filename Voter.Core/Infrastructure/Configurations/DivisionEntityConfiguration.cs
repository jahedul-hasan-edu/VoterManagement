using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class DivisionEntityConfiguration : IEntityTypeConfiguration<Division>
{
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.ToTable(nameof(Division));

        builder.HasKey(d => d.Id);
    }
}
