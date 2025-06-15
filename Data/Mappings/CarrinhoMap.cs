using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWearApi.Models;

public class CarrinhoMap : IEntityTypeConfiguration<CarrinhoModel>
{
    public void Configure(EntityTypeBuilder<CarrinhoModel> builder)
    {
        builder.ToTable("Carrinho");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd();

        builder.Property(c => c.DataCriacao)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.HasMany(c => c.ItensCarrinho)
               .WithOne(i => i.Carrinho)
               .HasForeignKey(i => i.CarrinhoId);

        builder.Property(c => c.UsuarioId)
       .IsRequired();

        builder.HasOne<UsuarioModel>()
               .WithOne()
               .HasForeignKey<CarrinhoModel>(c => c.UsuarioId);
    }



}
