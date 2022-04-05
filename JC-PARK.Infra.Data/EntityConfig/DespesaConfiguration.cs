using JC_PARK.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class DespesaConfiguration : EntityTypeConfiguration<Despesa>
    {
        public DespesaConfiguration()
        {
            HasKey(d => d.DespesaId);

            Property(d => d.EventoId)
                .IsRequired();

            Property(d => d.DataCadastro)
                .HasColumnType("datetime2");

            Property(d => d.ValorEntrada)
                .IsRequired();

            Property(d => d.ValorDespesa)
                .IsRequired();

            HasRequired(d => d.Eventos)
                .WithMany()
                .HasForeignKey(e => e.EventoId);

            ToTable("Despesas", "dbo");
        }
    }
}
