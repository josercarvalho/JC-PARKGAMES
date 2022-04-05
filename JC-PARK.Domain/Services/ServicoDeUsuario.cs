using System;
using System.Collections.Generic;
using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeUsuario : ServicoBase<Usuario>, IServicoDeUsuario
    {
        private readonly IRepositorioDeUsuarios _repositorioUsuario;
        private readonly IRepositorioDePerfilDeUsuario _repositorioPerfil;

        public ServicoDeUsuario(IRepositorioBase<Usuario> repositorio, IRepositorioDeUsuarios repositorioUsuario, IRepositorioDePerfilDeUsuario repositorioPerfil) 
            : base(repositorio)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioPerfil = repositorioPerfil;
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuarioRetorno = _repositorioUsuario.LogaUsuario(email, senha);
            return usuarioRetorno;
        }

        public Usuario RecuperaUsuarioPorEmail(string email)
        {
            var usuarioRetorno = _repositorioUsuario.RecuperarUsuarioPorEmail(email);
            return usuarioRetorno;
        }

        public List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilUsuario)
        {
             var usuariosDoPerfil = _repositorioPerfil.RetornaUsuariosDoPerfil(idPerfilUsuario);
            return usuariosDoPerfil;
        }

        public List<PerfilUsuario> RecuperaTodosPerfisAtivos()
        {
            return _repositorioPerfil.RecuperarTodos().Where(x => x.FlAtivo && !x.FlAdminMaster).ToList();
        }

        public void CadastraUsuario(Usuario usuario)
        {
            try
            {
                //IniciarTransação();
                _repositorioUsuario.CadastraUsuario(usuario);
                //PersistirTransação();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Usuario RecuperarUsuarioPorNome(string nome)
        {
            return _repositorioUsuario.RecuperarUsuarioPorNome(nome);
        }

    }
}
