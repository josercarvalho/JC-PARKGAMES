using JC_PARK.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class EventoUsuarioConfiguration : EntityTypeConfiguration<EventoUsuario>
    {
        public EventoUsuarioConfiguration()
        {
            HasKey(e => e.EventoUsuarioId);

            Property(e => e.DataCadastro)
                .HasColumnType("datetime2");

            Property(e => e.HoraEntrada)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(e => e.HoraSaida)
                .IsRequired()
                .HasColumnType("datetime2");

            HasRequired(e => e.EventosLista)
                .WithMany();

            HasRequired(e => e.UsuarioLista)
                .WithMany();
            
            ToTable("EventoUsuario", "dbo");
        }
    }
}
