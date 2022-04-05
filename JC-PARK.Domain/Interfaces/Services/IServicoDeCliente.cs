using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDeCliente : IServicoBase<Cliente>
    {
        Cliente BuscaPorNome(string nome);
    }
}
