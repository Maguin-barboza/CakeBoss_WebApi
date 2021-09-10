﻿// <auto-generated />
using CakeBoss.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CakeBoss.WebApi.Migrations
{
    [DbContext(typeof(CakeBossContext))]
    partial class CakeBossContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CakeBoss.WebApi.Models.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("OrdemVisualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Tbl_Imagens");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.Kit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Desconto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(MAX)");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Kits");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Multiplicador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(MAX)");

                    b.Property<double>("PrUnit")
                        .HasColumnType("float");

                    b.Property<decimal>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Tbl_Produtos");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.ProdutoKit", b =>
                {
                    b.Property<int>("KitId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("KitId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Tbl_Produtos_Kit");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.Imagem", b =>
                {
                    b.HasOne("CakeBoss.WebApi.Models.Produto", "Produto")
                        .WithMany("Imgens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.ProdutoKit", b =>
                {
                    b.HasOne("CakeBoss.WebApi.Models.Kit", "Kit")
                        .WithMany("ProdutosKit")
                        .HasForeignKey("KitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CakeBoss.WebApi.Models.Produto", "Produto")
                        .WithMany("ProdutosKit")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kit");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.Kit", b =>
                {
                    b.Navigation("ProdutosKit");
                });

            modelBuilder.Entity("CakeBoss.WebApi.Models.Produto", b =>
                {
                    b.Navigation("Imgens");

                    b.Navigation("ProdutosKit");
                });
#pragma warning restore 612, 618
        }
    }
}
