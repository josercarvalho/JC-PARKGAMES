using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Infra.Data.Initializer
{
    public class UserDatabaseInitializer
    {
        public static List<PerfilUsuario> GetPerfisUsuarios()
        {
            var perfisUsuario = new List<PerfilUsuario>
            {
                new PerfilUsuario
                {
                    PerfilUsuarioId = 1,
                    DataCadastro = DateTime.Now,
                    FlAdminMaster =true,
                    FlAtivo = true,
                    NomPerfil = "Administrador Master"
                },
                new PerfilUsuario
                {
                    PerfilUsuarioId = 2,
                    DataCadastro = DateTime.Now,
                    FlAdminMaster =true,
                    FlAtivo = true,
                    NomPerfil = "Usuário Master"
                },
                new PerfilUsuario
                {
                    PerfilUsuarioId = 3,
                    DataCadastro = DateTime.Now,
                    FlAdminMaster =true,
                    FlAtivo = true,
                    NomPerfil = "Usuário Padrão"
                }
            };
            return perfisUsuario;
        }

        public static List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    UsuarioId = 1,
                    Nome = "admin",
                    DataCadastro = DateTime.Now,
                    Email = "admin@ultragamespark.com.br",
                    PerfilUsuarioId = 1,
                    Senha = "@Senha2016",
                    SenhaKey = "@Senha2016",
                    TipoContrato = Domain.Enum.TipoContrato.Mensal
                },
                new Usuario
                {
                    UsuarioId = 2,
                    Nome = "José Ribeiro",
                    DataCadastro = DateTime.Now,
                    Email = "josercarvalho@gmail.com",
                    PerfilUsuarioId = 3,
                    Senha = "@Senha2016",
                    SenhaKey = "@Senha2016",
                    TipoContrato = Domain.Enum.TipoContrato.Mensal
                }
            };
            return usuarios;
        }
    }
}
