using Microsoft.EntityFrameworkCore;

using CakeBoss.WebApi.Models;
using System.Collections.Generic;

namespace CakeBoss.WebApi.Data
{
    public class CakeBossContext: DbContext
    {
        public CakeBossContext(DbContextOptions<CakeBossContext> options): base(options) {  }

        public DbSet<Produto> Tbl_Produtos { get; set; }
        public DbSet<Kit> Tbl_Kits { get; set; }
        public DbSet<ProdutoKit> Tbl_Produtos_Kit { get; set; }
        public DbSet<Imagem> Tbl_Imagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definindo valores padrões
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasDefaultValue(0);
            modelBuilder.Entity<Produto>().Property(p => p.Multiplicador).HasDefaultValue(0);
            modelBuilder.Entity<ProdutoKit>().Property(pk=> pk.Quantidade).HasDefaultValue(0);
            modelBuilder.Entity<Kit>().Property(k => k.Desconto).HasDefaultValue(0);
            modelBuilder.Entity<Imagem>().Property(i => i.OrdemVisualizacao).HasDefaultValue(0);
            modelBuilder.Entity<ProdutoKit>().HasKey(pk => new {pk.KitId, pk.ProdutoId});


            //Carga Inicial
            // modelBuilder.Entity<Produto>().HasData(new List<Produto>{
            //         new Produto("Bolo de pote sabor brigadeiro", 8.5, "Bolo de brigadeiro com cacau 100%", 1),
            //         new Produto("Fatia de bolo sabor Ferrero Rocher", 7, "Fatia de bolo sabor Ferrero Rocher", 1),
            //         new Produto("Fatia de bolo sabor Ninho com geleia de morango", 7.00, "Fatia de bolo sabor Ninho com geleia de morango", 1),
            //         new Produto("Tortinha de limão", 6.00, "Tortinha de limão", 1),
            //         new Produto("Cento de salgados fritos tamanho Festa", 60, "O Cento", 1),
            //         new Produto("Meio cento de salgados fritos Tamanho Festa", 30, string.Empty, 1),
            //         new Produto("Mini Naked", 50, "Bolo mini naked de 10 fatias com direito a dois recheios. (Topper não incluso)", 1),
            //         new Produto("Bolo 16 fatias", 100, "Bolo confeitado com direito a dois recheios. Serve 16 fatias. (Topper não incluso)", 1)
            //     });
            
            // modelBuilder.Entity<Imagem>().HasData(new List<Imagem>{
            //         new Imagem(1, @"C:\Imagens\bolodepote.jpg", "foto de bolo de pote", 1),
            //         new Imagem(2, @"C:\Imagens\fatia1.jpg", "fatia1", 1),
            //         new Imagem(3, @"C:\Imagens\fatia2.jpg", "fatia2", 1),
            //         new Imagem(4, @"C:\Imagens\tortinha.jpg", "tortinha", 1),
            //         new Imagem(7, @"C:\Imagens\mininaked1.jpg", "mininaked", 1),
            //         new Imagem(7, @"C:\Imagens\mininaked2.jpg", "mininaked", 2),
            //         new Imagem(7, @"C:\Imagens\mininaked3.jpg", "mininaked", 3),
            //         new Imagem(7, @"C:\Imagens\mininaked4.jpg", "mininaked", 4),
            //         new Imagem(6, @"C:\Imagens\meiocentosalgado1.jpg", "meiocentosalgado", 1),
            //         new Imagem(6, @"C:\Imagens\meiocentosalgado2.jpg", "meiocentosalgado", 2),
            //         new Imagem(6, @"C:\Imagens\meiocentosalgado3.jpg", "meiocentosalgado", 3),
            //         new Imagem(6, @"C:\Imagens\meiocentosalgado4.jpg", "meiocentosalgado", 4),
            //         new Imagem(8, @"C:\Imagens\Bolo16fatias1.jpg", "Bolo16fatias", 1),
            //         new Imagem(8, @"C:\Imagens\Bolo16fatias2.jpg", "Bolo16fatias", 2),
            //         new Imagem(8, @"C:\Imagens\Bolo16fatias3.jpg", "Bolo16fatias", 3),
            //         new Imagem(8, @"C:\Imagens\Bolo16fatias4.jpg", "Bolo16fatias", 4),
            //         new Imagem(5, @"C:\Imagens\centosalgado1.jpg", "meiocentosalgado", 1),
            //         new Imagem(5, @"C:\Imagens\centosalgado2.jpg", "meiocentosalgado", 2),
            //         new Imagem(5, @"C:\Imagens\centosalgado3.jpg", "meiocentosalgado", 3)
            //     });

            // modelBuilder.Entity<Kit>().HasData(new List<Kit>{
            //     new Kit("Bolo 16 fatias + Cento de salgado", 0, string.Empty),
            //     new Kit("Mini Naked + Meio cento de salgado", 0, string.Empty)
            // });
        }
    }
}