using JC_PARK.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class PontoConfiguration : EntityTypeConfiguration<Ponto>
    {
        public PontoConfiguration()
        {
            HasKey(p => p.PontoId);

            Property(t => t.DataCadastro)
                .HasColumnType("datetime2");

            Property(p => p.HoraEntrada)
                .HasColumnType("datetime2");

            Property(p => p.HoraSaida)
                .HasColumnType("datetime2");

            HasRequired(c => c.Eventos)
                .WithMany()
                .HasForeignKey(e => e.EventoId);

            HasRequired(c => c.Usuarios)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);

            ToTable("Ponto", "dbo");
        }
    }
}
