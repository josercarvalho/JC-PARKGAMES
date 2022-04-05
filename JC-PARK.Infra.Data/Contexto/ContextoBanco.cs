using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using JC_PARK.Infra.Data.EntityConfig;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.Contexto
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco()
            : base("JC-ParkConection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClientesEvento> ClientesEvento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoUsuario> EventosUsuario { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<TipoValor> TipoValores { get; set; }
        public DbSet<Valores> Valores { get; set; }
        public DbSet<Ponto> Ponto { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            modelBuilder.Properties<string>().Where(p => p.Name.Contains("UF"))
                .Configure(p => p.HasMaxLength(2));

            modelBuilder.Configurations.Add(new EventoConfiguration());
            modelBuilder.Configurations.Add(new EventoUsuarioConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ClienteEventoConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new DespesaConfiguration());
            modelBuilder.Configurations.Add(new EtiquetaConfiguration());
            modelBuilder.Configurations.Add(new TipoValorConfiguration());
            modelBuilder.Configurations.Add(new ValorConfiguration());
            modelBuilder.Configurations.Add(new PerfilUsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PontoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();

        }
    }
}