using CodeWearApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CodeWearApi.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nome)
                   .IsRequired()
                   .HasColumnName("Role")
                   .HasMaxLength(255);
        }
    }
}
