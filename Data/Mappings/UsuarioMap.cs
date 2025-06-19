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
            .HasColumnType("INT")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(u => u.NomeCompleto)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(u => u.Senha)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasOne(u => u.Role)
               .WithMany(r => r.Usuarios)
               .HasForeignKey(u => u.RoleId);
    }
}
