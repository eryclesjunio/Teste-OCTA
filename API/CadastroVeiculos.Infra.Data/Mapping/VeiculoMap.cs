using CadastroVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CadastroVeiculos.Infra.Data.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(prop => prop.Id)
                .HasName("Id");

            builder.Property(prop => prop.Marca)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Marca")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CpfCnpj)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("CpfCnpj")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Placa)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Placa")
                .HasColumnType("varchar(100)");

        }
    }
}
