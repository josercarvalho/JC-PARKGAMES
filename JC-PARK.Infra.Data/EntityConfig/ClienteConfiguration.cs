using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.NomeCrianca)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_dbo.Cliente.NomeCrianca-Nascimento", 0) { IsUnique = true }));

            Property(c => c.NomePai)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.TelefonePai)
                .IsRequired();

            Property(c => c.Sexo)
                .IsRequired();

            Property(c => c.Nascimento)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(c => c.DataCadastro)
                .HasColumnType("datetime2");

            ToTable("Clientes", "dbo");

        }
    }
}
