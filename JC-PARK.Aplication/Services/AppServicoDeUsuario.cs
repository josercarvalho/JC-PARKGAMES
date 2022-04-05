using System;
using System.Collections.Generic;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeUsuario : AppServicoBase<Usuario>, IAppServicoDeUsuario
    {
        private readonly IServicoDeUsuario _servicoDeUsuario;
        private readonly IServicoDePerfilUsuario _servicoDePerfilUsuario;

        public AppServicoDeUsuario(IServicoBase<Usuario> serviceBase, IServicoDeUsuario servicoDeUsuario, IServicoDePerfilUsuario servicoDePerfilUsuario) 
            : base(serviceBase)
        {
            _servicoDeUsuario = servicoDeUsuario;
            _servicoDePerfilUsuario = servicoDePerfilUsuario;
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuarioRetorno = _servicoDeUsuario.LogaUsuario(email, senha);
            return usuarioRetorno;
        }

        public Usuario RecuperaUsuarioPorEmail(string email)
        {
            var usuarioRetorno = _servicoDeUsuario.RecuperaUsuarioPorEmail(email);
            return usuarioRetorno;
        }

        public List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilUsuario)
        {
            var usuariosDoPerfil = _servicoDeUsuario.RecuperaUsuariosDoPerfil(idPerfilUsuario);
            return usuariosDoPerfil; 
        }

        public List<PerfilUsuario> RecuperaTodosPerfisAtivos()
        {
            IEnumerable<PerfilUsuario> retorno = _servicoDePerfilUsuario.RecuperarTodos();
            return retorno as List<PerfilUsuario>;
        }

        public void CadastraUsuario(Usuario usuario)
        {
            try
            {
                _servicoDeUsuario.CadastraUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Usuario RecuperarUsuarioPorNome(string nome)
        {
            return _servicoDeUsuario.RecuperarUsuarioPorNome(nome);
        }

    }
}
