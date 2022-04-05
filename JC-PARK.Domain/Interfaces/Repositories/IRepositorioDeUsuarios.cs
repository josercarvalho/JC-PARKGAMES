using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeUsuarios : IRepositorioBase<Usuario>
    {
        Usuario RecuperarUsuarioPorEmail(string email);
        Usuario RecuperarUsuarioPorNome(string nome);
        Usuario LogaUsuario(string email, string senha);
        Usuario CadastraUsuario(Usuario user);
    }
}
