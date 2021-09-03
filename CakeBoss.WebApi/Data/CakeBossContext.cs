using Microsoft.EntityFrameworkCore;

using CakeBoss.WebApi.Models;

namespace CakeBoss.WebApi.Data
{
    public class CakeBossContext: DbContext
    {
        public CakeBossContext(DbContextOptions<CakeBossContext> options): base(options) {  }

        public DbSet<Produto> Tbl_Produtos { get; set; }
        public DbSet<Kit> Tbl_Kits { get; set; }
        public DbSet<Imagem> Tbl_Imagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasDefaultValue(0);
            modelBuilder.Entity<Produto>().Property(p=> p.Quantidade).HasDefaultValue(0);
            
            modelBuilder.Entity<Kit>().Property(k => k.Desconto).HasDefaultValue(0);
            
            modelBuilder.Entity<Imagem>().Property(i => i.OrdemVisualizacao).HasDefaultValue(0);
        }
    }
}