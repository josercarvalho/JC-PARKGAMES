using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class PerfilUsuarioConfiguration : EntityTypeConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioConfiguration()
        {
            HasKey(t => t.PerfilUsuarioId);

            Property(t => t.NomPerfil)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.DataCadastro)
                .HasColumnType("datetime2");

            ToTable("PerfilUsuarios", "dbo");
        }
    }
}
