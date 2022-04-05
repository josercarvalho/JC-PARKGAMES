using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(t => t.UsuarioId);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.Email)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnAnnotation(
               IndexAnnotation.AnnotationName,
               new IndexAnnotation(
                   new IndexAttribute("IX_LoginNameUser", 1) { IsUnique = true }));

            Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(2048);

            Property(t => t.DataCadastro)
                .HasColumnType("date");

            //Property(e => e.TipoContrato)
            //    .IsRequired();

            //Property(e => e.Salario)
            //    .IsRequired();

            HasRequired(t => t.PerfilUsuario)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.PerfilUsuarioId);

            ToTable("Usuarios", "dbo");
        }
    }
}
