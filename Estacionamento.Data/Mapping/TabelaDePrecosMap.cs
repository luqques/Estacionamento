using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Mapping
{
    public class TabelaDePrecosMap
    {
        public void Configure(EntityTypeBuilder<TabelaDePrecosEntity> builder)
        {
            builder.ToTable("TabelaDePrecos");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.PrecoHora)
                .HasColumnName("PrecoHora")
                .HasColumnType("decimal(10,2)");
            
            builder.Property(prop => prop.DataHoraCadastro)
                .HasColumnName("DataHoraCadastro")
                .HasColumnType("datetime");

        }
    }
}
