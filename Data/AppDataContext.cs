using CodeWearApi.Data.Mappings;
using CodeWearApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Data
{
    public class AppDataContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDataContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CarrinhoModel> Carrinhos { get; set; }
        public DbSet<ItemCarrinhoModel> ItemsCarrinho { get; set; }
        public DbSet<ComentarioModel> Comentarios { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<ImagemProdutoModel> ImagensProduto {get;set;}

        public DbSet<ColecaoModel> Colecoes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarrinhoMap());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new ImagemProdutoMap());
            modelBuilder.ApplyConfiguration(new ColecaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
