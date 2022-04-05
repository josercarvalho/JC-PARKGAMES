using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeEtiqueta : IRepositorioBase<Etiqueta>
    {
        Etiqueta GeraEtiqueta();
    }
}
