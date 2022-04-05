using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDeUsuario : IServicoBase<Usuario>
    {
        Usuario LogaUsuario(string email, string senha);
        Usuario RecuperarUsuarioPorNome(string nome);
        Usuario RecuperaUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilUsuario);
        List<PerfilUsuario> RecuperaTodosPerfisAtivos();
        void CadastraUsuario(Usuario usuario);
    }
}
