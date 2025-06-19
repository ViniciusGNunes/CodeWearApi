using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class CarrinhoMap : IEntityTypeConfiguration<CarrinhoModel>
{
    public void Configure(EntityTypeBuilder<CarrinhoModel> builder)
    {
        builder.ToTable("Carrinho");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataCriacao)
               .IsRequired();

        builder.Property(c => c.Finalizado)
               .IsRequired();

    }
}
