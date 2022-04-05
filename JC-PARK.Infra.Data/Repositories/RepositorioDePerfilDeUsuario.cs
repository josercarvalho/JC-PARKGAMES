using System.Collections.Generic;
using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDePerfilDeUsuario : RepositorioBase<PerfilUsuario>, IRepositorioDePerfilDeUsuario
    {
        public List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario)
        {
            var perfil = _contexto.PerfilUsuario.FirstOrDefault(x => x.PerfilUsuarioId == idPerfilUsuario);
            return perfil != null ? perfil.Usuarios.ToList() : null;
        }
    }
}
