using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class VoterAreaEntityConfiguration : IEntityTypeConfiguration<VoterArea>
{
    public void Configure(EntityTypeBuilder<VoterArea> builder)
    {
        builder.HasKey(v => v.Id);

        builder.HasOne(v => v.Corporation)
               .WithMany(c => c.VoterAreas)
               .HasForeignKey(v => v.CorporationId);

        builder.HasOne(v => v.UnionCouncil)
               .WithMany(u => u.VoterAreas)
               .HasForeignKey(v => v.UnionCouncilId);

        builder.HasOne(v => v.PostOffice)
               .WithMany(p => p.VoterAreas)
               .HasForeignKey(v => v.PostOfficeId);
    }
}
