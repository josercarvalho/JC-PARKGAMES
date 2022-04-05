using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDaEmpresa : ServicoBase<Empresa>, IServicoDaEmpresa
    {
        private readonly IRepositorioDaEmpresa _repositorioDaEmpresa;
        public ServicoDaEmpresa(IRepositorioDaEmpresa repositorioDaEmpresa)
            : base(repositorioDaEmpresa)
        {
            _repositorioDaEmpresa = repositorioDaEmpresa;
        }
    }
}
