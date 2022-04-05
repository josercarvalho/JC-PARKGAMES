using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class EventoConfiguration : EntityTypeConfiguration<Evento>
    {
        public EventoConfiguration()
        {
            HasKey(e => e.EventoId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Local)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.UF)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.DataCadastro)
                .HasColumnType("date");

            Property(e => e.DataInicial)
                .IsRequired()
                .HasColumnType("date");

            Property(e => e.DataFinal)
                .IsRequired()
                .HasColumnType("date");

            Property(e => e.ValorPatio)
                .IsRequired();

            ToTable("Eventos", "dbo");
        }
    }
}
