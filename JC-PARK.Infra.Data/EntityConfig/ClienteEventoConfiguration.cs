using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class ClienteEventoConfiguration : EntityTypeConfiguration<ClientesEvento>
    {
        public ClienteEventoConfiguration()
        {
            HasKey(c => c.ClienteEventoId);

            Property(c => c.ClienteId)
                .IsRequired();

            Property(c => c.EventoId)
                .IsRequired();

            Property(t => t.DataCadastro)
                .HasColumnType("datetime2");

            Property(t => t.HoraEntrada)
                .HasColumnType("datetime2");

            Property(t => t.HoraSaida)
                .HasColumnType("datetime2");

            Property(c => c.EtiquetaId)
                .IsRequired()
               .HasColumnAnnotation(
               IndexAnnotation.AnnotationName,
               new IndexAnnotation(
                   new IndexAttribute("IX_ClienteEtiqueta", 1) { IsUnique = true }));

            HasRequired(c => c.Evento)
                .WithMany()
                .HasForeignKey(e => e.EventoId);

            HasRequired(c => c.Cliente)
                .WithMany()
                .HasForeignKey(e => e.ClienteId);

            ToTable("ClientesEvento", "dbo");
        }

    }
}
