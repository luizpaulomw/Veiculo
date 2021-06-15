
using System;
using Conexão_banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Veiculo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210601003022_bancoveiculo")]
    partial class bancoveiculo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Models.ClienteModels", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CpfCliente")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("DiasDevolucao")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Models.LocacaoModels", b =>
                {
                    b.Property<int>("IdLocacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.HasKey("IdLocacao");

                    b.HasIndex("ClienteIdCliente");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("Models.LocacaoVeiculoModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdLocacao")
                        .HasColumnType("int");

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<int?>("LocacaoIdLocacao")
                        .HasColumnType("int");

                    b.Property<int?>("VeiculoIdVeiculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoIdLocacao");

                    b.HasIndex("VeiculoIdVeiculo");

                    b.ToTable("LocacaoVeiculo");
                });

            modelBuilder.Entity("Models.VeiculoModels", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ano")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("EstoqueVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("ValorLocacaoVeiculo")
                        .HasColumnType("double");

                    b.Property<int>("VeiculoLocado")
                        .HasColumnType("int");

                    b.HasKey("IdVeiculo");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Models.LocacaoModels", b =>
                {
                    b.HasOne("Models.ClienteModels", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente");
                });

            modelBuilder.Entity("Models.LocacaoVeiculoModels", b =>
                {
                    b.HasOne("Models.LocacaoModels", "Locacao")
                        .WithMany()
                        .HasForeignKey("LocacaoIdLocacao");

                    b.HasOne("Models.VeiculoModels", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoIdVeiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
