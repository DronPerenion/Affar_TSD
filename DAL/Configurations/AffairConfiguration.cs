using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class AffairConfiguration : IEntityTypeConfiguration<Affair>
    {
        public void Configure(EntityTypeBuilder<Affair> builder)
        {
            builder.ToTable("Affairs");

            builder.HasIndex(a => a.Id)
                .IsUnique();
        }
    }
}