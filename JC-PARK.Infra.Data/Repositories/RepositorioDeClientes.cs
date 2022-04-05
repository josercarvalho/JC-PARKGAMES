using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeClientes : RepositorioBase<Cliente>, IRepositorioDeClientes
    {
        public Cliente BuscaPorNome(string nome)
        {
            return _contexto.Clientes.FirstOrDefault(c => c.NomeCrianca == nome);
        }
    }
}
