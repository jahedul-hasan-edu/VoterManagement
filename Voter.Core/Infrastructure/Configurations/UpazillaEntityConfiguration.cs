using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class UpazillaEntityConfiguration : IEntityTypeConfiguration<Upazilla>
{
    public void Configure(EntityTypeBuilder<Upazilla> builder)
    {
        builder.ToTable(nameof(Upazilla));

        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.Zilla)
               .WithMany(z => z.Upazillas)
               .HasForeignKey(u => u.ZillaId);
    }
}