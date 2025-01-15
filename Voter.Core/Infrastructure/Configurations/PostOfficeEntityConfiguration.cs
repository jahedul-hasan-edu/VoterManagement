using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Voter.Core.Entities;

namespace Voter.Core.Infrastructure.Configurations;

public class PostOfficeEntityConfiguration : IEntityTypeConfiguration<PostOffice>
{
    public void Configure(EntityTypeBuilder<PostOffice> builder)
    {
        builder.ToTable(nameof(PostOffice));

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Upazilla)
               .WithMany(u => u.PostOffices)
               .HasForeignKey(p => p.UpazillaId);
    }
}
