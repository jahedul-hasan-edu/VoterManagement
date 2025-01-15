using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class CorporationEntityConfiguration : IEntityTypeConfiguration<Corporation>
{
    public void Configure(EntityTypeBuilder<Corporation> builder)
    {
        builder.ToTable(nameof(Corporation));

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Zilla)
               .WithMany(z => z.Corporations)
               .HasForeignKey(c => c.ZillaId);
    }
}
