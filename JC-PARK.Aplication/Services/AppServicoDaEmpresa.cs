using System;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDaEmpresa : AppServicoBase<Empresa>, IAppServicoDaEmpresa
    {
        private readonly IServicoDaEmpresa _servicoDaEmpresa;

        public AppServicoDaEmpresa(IServicoDaEmpresa servicoDaEmpresa)
            : base(servicoDaEmpresa)
        {
            _servicoDaEmpresa = servicoDaEmpresa;
        }
    }
}
