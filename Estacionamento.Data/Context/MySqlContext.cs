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

        public DbSet<VeiculoEntity> Veiculos { get; set; }
        public DbSet<RegistroEstacionamentoEntity> RegistrosEstacionamento { get; set; }
        public DbSet<TabelaDePrecosEntity> TabelaDePrecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VeiculoEntity>(new VeiculoMap().Configure);
            modelBuilder.Entity<RegistroEstacionamentoEntity>(new RegistroEstacionamentoMap().Configure);
            modelBuilder.Entity<TabelaDePrecosEntity>(new TabelaDePrecosMap().Configure);
        }
    }
}
