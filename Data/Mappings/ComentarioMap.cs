using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class ComentarioMap : IEntityTypeConfiguration<ComentarioModel>
{
    public void Configure(EntityTypeBuilder<ComentarioModel> builder)
    {
        builder.ToTable("Comentario");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd();

        builder.Property(c => c.Texto)
               .IsRequired()
               .HasMaxLength(240);

        builder.Property(c => c.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasColumnType("INT");
    }
}
