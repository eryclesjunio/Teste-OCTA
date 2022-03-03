using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CadastroVeiculos.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);
            modelBuilder.Entity<Proprietario>(new ProprietarioMap().Configure);
        }
    }
}
