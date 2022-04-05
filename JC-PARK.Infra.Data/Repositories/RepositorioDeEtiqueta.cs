using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeEtiqueta : RepositorioBase<Etiqueta>, IRepositorioDeEtiqueta
    {
        public Etiqueta GeraEtiqueta()
        {
            throw new System.NotImplementedException();
        }
    }
}
