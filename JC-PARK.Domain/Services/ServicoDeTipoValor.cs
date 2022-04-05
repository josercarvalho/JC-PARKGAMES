using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeTipoValor : ServicoBase<TipoValor>, IServicoDeTipoValor
    {
        private readonly IRepositorioDeTipoValor _repositorioDeTipoValor;

        public ServicoDeTipoValor(IRepositorioDeTipoValor repositorioDeTipoValor)
            : base(repositorioDeTipoValor)
        {
            _repositorioDeTipoValor = repositorioDeTipoValor;
        }
    }
}
