namespace CodeWearApi.Data.Mappings
{
    using CodeWearApi.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ColecaoMap : IEntityTypeConfiguration<ColecaoModel>
    {
        public void Configure(EntityTypeBuilder<ColecaoModel> builder)
        {
            builder.ToTable("Colecoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(140);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(140);
        }
    }

}
