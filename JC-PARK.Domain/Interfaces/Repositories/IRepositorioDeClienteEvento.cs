using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeClienteEvento : IRepositorioBase<ClientesEvento>
    {
        ClientesEvento BuscaPorEvento(int evento);
        ClientesEvento BuscaPorEtiqueta(int etiqueta);
        bool BuscaEtiquetaAtiva(int etiqueta);
    }
}
