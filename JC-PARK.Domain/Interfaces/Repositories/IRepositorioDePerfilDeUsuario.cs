using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDePerfilDeUsuario : IRepositorioBase<PerfilUsuario>
    {
        List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario);
    }
}
