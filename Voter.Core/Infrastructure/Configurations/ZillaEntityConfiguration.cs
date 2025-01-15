using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class ZillaEntityConfiguration : IEntityTypeConfiguration<Zilla>
{
    public void Configure(EntityTypeBuilder<Zilla> builder)
    {
        builder.ToTable(nameof(Zilla));

        builder.HasKey(z => z.Id);

        builder.HasOne(z => z.Division)
               .WithMany(d => d.Zillas)
               .HasForeignKey(z => z.DivisionId);
    }
}
