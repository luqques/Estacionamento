using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Data.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<VeiculoEntity>
    {
        public void Configure(EntityTypeBuilder<VeiculoEntity> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Placa)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Placa")
                .HasColumnType("varchar(10)");

            builder.Property(prop => prop.NomeProprietario)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("NomeProprietario")
                .HasColumnType("varchar(250)");

            builder.Property(prop => prop.Modelo)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Modelo")
                .HasColumnType("varchar(250)");
        }
    }
}
