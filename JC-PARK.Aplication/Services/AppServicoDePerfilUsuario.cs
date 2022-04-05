using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDePerfilUsuario : AppServicoBase<PerfilUsuario>, IAppServicoDePerfilUsuario
    {
        private readonly IServicoDePerfilUsuario _servicoDePerfilUsuario;

        public AppServicoDePerfilUsuario(IServicoBase<PerfilUsuario> servicoDePerfilUsuario, IServicoDePerfilUsuario servicoDePerfilUsuario1)
            : base(servicoDePerfilUsuario)
        {
            _servicoDePerfilUsuario = servicoDePerfilUsuario1;
        }
    }
}
