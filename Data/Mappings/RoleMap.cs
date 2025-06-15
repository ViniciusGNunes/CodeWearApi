using CodeWearApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWearApi.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder.Property(p => p.Role)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("NVARCHAR");
        }
    }
}
