using System.IO;
using JC_PARK.Infra.Data.Initializer;

namespace JC_PARK.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.ContextoBanco>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.ContextoBanco context)
        {
            if (!context.PerfilUsuario.Any(x => x.NomPerfil == "Administrador Master"))
                UserDatabaseInitializer.GetPerfisUsuarios().ForEach(c => context.PerfilUsuario.Add(c));

            if (!context.Usuarios.Any(x => x.Nome == "admin"))
                UserDatabaseInitializer.GetUsuarios().ForEach(c => context.Usuarios.Add(c));

            // Delete all stored procs, views
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\Seed"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }

            // Add Stored Procedures
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\StoredProcs"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }
        }
    }
}
