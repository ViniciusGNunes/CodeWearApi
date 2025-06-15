using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
{
    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .ValueGeneratedOnAdd();

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(120);

        builder.Property(u => u.NomeCompleto)
               .IsRequired()
               .HasMaxLength(120);

        builder.Property(u => u.Password)
               .HasMaxLength(120);

        builder.Property(u => u.RoleId)
               .HasColumnType("int");
    }
}
