using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class TipoValorConfiguration : EntityTypeConfiguration<TipoValor>
    {
        public TipoValorConfiguration()
        {
            HasKey(t => t.TipoValorId);

            Property(t => t.Nome)
                .IsRequired();

            Property(t => t.DataCadastro)
                .HasColumnType("datetime2");

            ToTable("TipoValores", "dbo");
        }
    }
}
