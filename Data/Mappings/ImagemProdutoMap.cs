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

            builder.HasKey(ip => ip.Id);

            builder.Property(ip => ip.Descricao)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(ip => ip.Imagem)
                   .IsRequired();

            builder.Property(ip => ip.TipoMime)
                   .HasMaxLength(100);

            builder.Property(ip => ip.ProdutoId)
                   .IsRequired();

            builder.HasOne<ProdutoModel>() // relacional se quiser navegação
                   .WithMany()
                   .HasForeignKey(ip => ip.ProdutoId);
        }
    }


}
