using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
{
    public void Configure(EntityTypeBuilder<ProdutoModel> builder)
    {
        builder.ToTable("Produto");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(p => p.TipoProduto)
               .HasMaxLength(255);

        builder.Property(p => p.Preco)  
               .IsRequired()
               .HasColumnType("decimal(10, 2)");

        builder.Property(p => p.ColecaoId)
            .HasColumnType("INT")
            .HasColumnName("ColecaoID");
    }
}
