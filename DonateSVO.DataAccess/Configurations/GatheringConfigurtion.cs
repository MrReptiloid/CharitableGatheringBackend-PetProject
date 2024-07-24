using DonateSVO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DonateSVO.DataAccess.Configurations;

public class GatheringConfiguration : IEntityTypeConfiguration<GatheringEntity>
{
    public void Configure(EntityTypeBuilder<GatheringEntity> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Title)
            .IsRequired();
        builder.Property(g => g.Description)
            .IsRequired();
        builder.Property(g => g.CreatedDate)
            .IsRequired();
        builder.Property(g => g.TargetAmount)
            .IsRequired();
        builder.Property(g => g.CurrentAmount)
            .IsRequired();
        builder.Property(g => g.MembersCount)
            .IsRequired();
        builder.Property(g => g.IsVerified)
            .IsRequired();
    }
}