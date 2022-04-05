using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class ValorConfiguration : EntityTypeConfiguration<Valores>
    {
        public ValorConfiguration()
        {
            HasKey(v => v.ValoresId);

            Property(v => v.ValorNormal)
                .IsRequired();

            Property(v => v.ValorEPorMinuto)
                .IsRequired();

            Property(v => v.ValorEPorHora)
                .IsRequired();

            HasRequired(t => t.TipoValores)
                .WithMany(t => t.Valor)
                .HasForeignKey(d => d.TipoValorId);

            HasRequired(v => v.Eventos)
                .WithMany()
                .HasForeignKey(t => t.EventoId);

            ToTable("Valores", "dbo");
        }
    }
}
