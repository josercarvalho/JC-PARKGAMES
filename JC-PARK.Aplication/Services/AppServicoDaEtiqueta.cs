using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDaEtiqueta : AppServicoBase<Etiqueta>, IAppServicoDaEtiqueta
    {
        private readonly IServicoDaEtiqueta _servicoDaEtiqueta;
        public AppServicoDaEtiqueta(IServicoDaEtiqueta servicoDaEtiqueta)
            : base(servicoDaEtiqueta)
        {
            _servicoDaEtiqueta = servicoDaEtiqueta;
        }
    }
}
