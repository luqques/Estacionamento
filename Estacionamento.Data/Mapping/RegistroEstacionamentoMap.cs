using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Mapping
{
    public class RegistroEstacionamentoMap : IEntityTypeConfiguration<RegistroEstacionamento>
    {
        public void Configure(EntityTypeBuilder<RegistroEstacionamento> builder)
        {
            builder.ToTable("RegistroEstacionamento");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.VeiculoId) //TODO: Verificar se não terá conflito sem o HasValue() igual no Veiculo
                .IsRequired()
                .HasColumnName("VeiculoId")
                .HasColumnType("int");

            builder.Property(prop => prop.DataHoraEntrada)
                .IsRequired()
                .HasColumnName("DataHoraEntrada")
                .HasColumnType("datetime");

            builder.Property(prop => prop.DataHoraSaida)
                .HasColumnName("DataHoraSaida")
                .HasColumnType("datetime");

            builder.Property(prop => prop.ValorCobrado)
                .HasColumnName("ValorCobrado")
                .HasColumnType("decimal(10,2)");
        }
    }
}
