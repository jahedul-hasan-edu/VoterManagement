using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class VoterMemberEntityConfiguration : IEntityTypeConfiguration<VoterMember>
{
    public void Configure(EntityTypeBuilder<VoterMember> builder)
    {
        builder.ToTable(nameof(VoterMember));

        builder.HasKey(x => x.Id);
    }
}
