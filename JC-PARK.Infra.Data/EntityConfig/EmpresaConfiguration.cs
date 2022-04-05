using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(e => e.EmpresaId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Local)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.UF)
                .IsRequired();

            Property(e => e.DataCadastro)
                .HasColumnType("date");

            ToTable("Empresas", "dbo");
        }
    }
}
