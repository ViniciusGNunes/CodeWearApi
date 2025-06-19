using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinhoModel>
{
    public void Configure(EntityTypeBuilder<ItemCarrinhoModel> builder)
    {
        builder.ToTable("ItemCarrinho");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Quantidade)
               .IsRequired();
    }
}
