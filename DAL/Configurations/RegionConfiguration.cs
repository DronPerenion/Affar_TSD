using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasMany(r => r.Departments)
                .WithOne(s => s.Region)
                .HasForeignKey(a => a.RegionId);
        }
    }
}