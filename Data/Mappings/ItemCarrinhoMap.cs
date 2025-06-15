using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinhoModel>
{
    public void Configure(EntityTypeBuilder<ItemCarrinhoModel> builder)
    {
        builder.ToTable("ItemCarrinho");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
               .ValueGeneratedOnAdd();

        builder.Property(i => i.Quantidade)
               .IsRequired();

        builder.HasOne(i => i.Carrinho)
               .WithMany(c => c.ItensCarrinho)
               .HasForeignKey(i => i.CarrinhoId);

        builder.HasOne(i => i.Produto)
               .WithMany(p => p.ItensCarrinho)
               .HasForeignKey(i => i.ProdutoId);
    }
}
