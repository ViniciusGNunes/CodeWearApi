using CodeWearApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWearApi.Data.Mappings
{
    public class ImagemProdutoMap : IEntityTypeConfiguration<ImagemProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ImagemProdutoModel> builder)
        {
            builder.ToTable("ImagemProduto");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Descricao)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(i => i.Caminho)
                   .IsRequired()
                   .HasMaxLength(500);


        }
    }

}
