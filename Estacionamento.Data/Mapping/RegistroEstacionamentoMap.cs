﻿using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Mapping
{
    public class RegistroEstacionamentoMap : IEntityTypeConfiguration<RegistroEstacionamentoEntity>
    {
        public void Configure(EntityTypeBuilder<RegistroEstacionamentoEntity> builder)
        {
            builder.ToTable("RegistroEstacionamentoEntity");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Veiculo.Id)
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

            builder.Property(prop => prop.ValorPagar)
                .HasColumnName("ValorPagar")
                .HasColumnType("decimal(10,2)");
        }
    }
}
