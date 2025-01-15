using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class UnionCouncilEntityConfiguration : IEntityTypeConfiguration<UnionCouncil>
{
    public void Configure(EntityTypeBuilder<UnionCouncil> builder)
    {
        builder.ToTable(nameof(UnionCouncil));
        
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.Upazilla)
               .WithMany(u => u.UnionCouncils)
               .HasForeignKey(u => u.UpazillaId);
    }
}
