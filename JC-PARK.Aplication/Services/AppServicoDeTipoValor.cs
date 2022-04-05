using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeTipoValor : AppServicoBase<TipoValor>, IAppServicoDeTipoValor
    {
        private readonly IServicoDeTipoValor _servicoDeTipoValor;
        public AppServicoDeTipoValor(IServicoDeTipoValor servicoDeTipoValor)
            : base(servicoDeTipoValor)
        {
            _servicoDeTipoValor = servicoDeTipoValor;
        }
    }
}
