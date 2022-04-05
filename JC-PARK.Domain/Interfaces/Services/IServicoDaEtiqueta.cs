using System.Linq;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDaEtiqueta : IServicoBase<Etiqueta>
    {
        IOrderedEnumerable<Etiqueta> PegaUltimaEtiquera();
    }
}
