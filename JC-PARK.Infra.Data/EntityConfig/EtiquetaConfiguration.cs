using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class EtiquetaConfiguration : EntityTypeConfiguration<Etiqueta>
    {
        public EtiquetaConfiguration()
        {
            HasKey(e => e.EtiquetaId);

            Property(e => e.Quantidade)
                .IsRequired();

            Property(e => e.DataCadastro)
                .HasColumnType("datetime2");

            ToTable("Etiquetas", "dbo");
        }
    }
}
