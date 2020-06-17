using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class PoliceDepartmentConfiguration : IEntityTypeConfiguration<PoliceDepartment>
    {
        public void Configure(EntityTypeBuilder<PoliceDepartment> builder)
        {
            builder.ToTable("PoliceDepartments");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasMany(a => a.Affairs)
                .WithOne(a => a.PoliceDepartment)
                .HasForeignKey(a => a.PoliceDepartmentId);
        }
    }
}
