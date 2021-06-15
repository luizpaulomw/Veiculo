using Microsoft.EntityFrameworkCore;
using Models;

namespace Conexão_banco
{
    public class Context : DbContext
    {
        public DbSet<ClienteModels> Clientes { get; set; }
        public DbSet<VeiculoModels> Veiculos { get; set; }
        public DbSet<LocacaoModels> Locacoes { get; set; }
        public DbSet<LocacaoVeiculoModels> LocacaoVeiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("Server=localhost;User Id=root;Database=bancoveiculo");
            
        }
    }
}