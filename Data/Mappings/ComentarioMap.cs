using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class ComentarioMap : IEntityTypeConfiguration<ComentarioModel>
{
    public void Configure(EntityTypeBuilder<ComentarioModel> builder)
    {
        builder.ToTable("Comentario");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Texto)
               .IsRequired();

    }
}
