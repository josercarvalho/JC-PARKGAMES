using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeClientes : IRepositorioBase<Cliente>
    {
        Cliente BuscaPorNome(string nome);
    }
}
