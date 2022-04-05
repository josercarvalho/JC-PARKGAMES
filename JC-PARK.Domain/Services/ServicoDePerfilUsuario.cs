using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDePerfilUsuario : ServicoBase<PerfilUsuario>, IServicoDePerfilUsuario
    {
        private readonly IRepositorioDePerfilDeUsuario _repositorioDePerfilDeUsuario;
        public ServicoDePerfilUsuario(IRepositorioDePerfilDeUsuario repositorioDePerfilDeUsuario)
            : base(repositorioDePerfilDeUsuario)
        {
            _repositorioDePerfilDeUsuario = repositorioDePerfilDeUsuario;
        }
    }
}
