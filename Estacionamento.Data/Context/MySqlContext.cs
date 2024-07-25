using Estacionamento.Data.Mapping;
using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<RegistroEstacionamento> RegistrosEstacionamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);
            modelBuilder.Entity<RegistroEstacionamento>(new RegistroEstacionamentoMap().Configure);
        }
    }
}
